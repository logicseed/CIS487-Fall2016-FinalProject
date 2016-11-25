// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generic mover for all space-based objects that use <see cref="MovementBehaviour"/>s to move.
/// </summary>
[RequireComponent(typeof(AgentManager))]
[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class StandardMover : MonoBehaviour
{
    /// <summary>
    /// The maximum velocity of this mover.
    /// </summary>
    public float maxVelocity;

    /// <summary>
    /// The maximum steering of this mover.
    /// </summary>
    public float maxSteering;

    

    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        UpdateMovement();
        RemoveDeletedBehaviours();
    }

    private AgentManager agent;
    private Rigidbody rigidBody;
    private List<MovementBehaviour> behaviours = new List<MovementBehaviour>();
    private List<MovementBehaviour> behavioursToRemove = new List<MovementBehaviour>();

    /// <summary>
    /// Updates <see cref="props"/> based on recent movement and behaviours.
    /// </summary>
    private void UpdateMovement()
    {
        // true for debugging
        var debugRays = true;

        var prioritySteering = CalculateSteeringForce(debugRays);
        var steering = Vector3.ClampMagnitude(prioritySteering, maxSteering);
 
        rigidBody.AddForce(steering, ForceMode.VelocityChange);

        if (debugRays)
        {
            // Unclamped acceleration
            Debug.DrawRay(transform.position + velocity,
                          prioritySteering, RayColor.Standard.UnclampedAcceleration);
            // Velocity vector
            Debug.DrawRay(transform.position, velocity, RayColor.Standard.Velocity);

            // Acceleration vector
            Debug.DrawRay(transform.position + velocity, steering, RayColor.Standard.Acceleration);
        }
    }

    /// <summary>
    /// Calculates a new velocity based on all of the mover's movement behaviours.
    /// </summary>
    /// <returns>Vector3 representing the new velocity.</returns>
    /// <remarks>
    /// Uses the Decorator pattern.
    /// </remarks>
    private Vector3 CalculateSteeringForce(bool debugRays = false)
    {
        //Debug.Log("Behaviours: " + behaviours.Count);
        AbstractBehaviourComponent movementBehaviours = new IdleBehaviourComponent(agent, new IdleBehaviour());
        movementBehaviours = new AvoidBehaviourDecorator(movementBehaviours, new AvoidBehaviour());

        foreach (var behaviour in behaviours)
        {
            switch (behaviour.type)
            {
                case BehaviourType.Seek:
                    movementBehaviours = new SeekBehaviourDecorator(movementBehaviours, behaviour);
                    break;
                case BehaviourType.Flee:
                    movementBehaviours = new FleeBehaviourDecorator(movementBehaviours, behaviour);
                    break;
                case BehaviourType.Wander:
                    movementBehaviours = new WanderBehaviourDecorator(movementBehaviours, behaviour);
                    break;
                case BehaviourType.Pursue:
                    movementBehaviours = new PursueBehaviourDecorator(movementBehaviours, behaviour);
                    break;
                case BehaviourType.Evade:
                    movementBehaviours = new EvadeBehaviourDecorator(movementBehaviours, behaviour);
                    break;
            }
        }

        return movementBehaviours.Steering(debugRays);
    }

    /// <summary>
    /// Removes all behaviours marked for removal from this mover.
    /// </summary>
    private void RemoveDeletedBehaviours()
    {
        if (behavioursToRemove.Count > 0)
        {
            foreach (var behaviour in behavioursToRemove)
            {
                behaviour.DeletingBehaviour -= new DeleteBehaviourHandler(RemoveBehaviour);
                behaviours.Remove(behaviour);
            }
            behavioursToRemove.Clear();
            behaviours.TrimExcess();
        }
    }



    /// <summary>
    /// Adds a behaviour to this mover.
    /// </summary>
    /// <param name="behaviour">The behaviour to add.</param>
    public void AddBehaviour(MovementBehaviour behaviour)
    {
        behaviour.DeletingBehaviour += new DeleteBehaviourHandler(RemoveBehaviour);
        behaviours.Add(behaviour);
    }

    /// <summary>
    /// Removes a behaviour from this mover.
    /// </summary>
    /// <param name="behaviour">The behaviour to add.</param>
    public void RemoveBehaviour(MovementBehaviour behaviour)
    {
        behavioursToRemove.Add(behaviour);
    }






    /// <summary>
    /// The agent's current velocity vector.
    /// </summary>
    public Vector3 velocity
    {
        get { return rigidBody.velocity; }
    }

    /// <summary>
    /// The agent's current heading vector.
    /// </summary>
    public Vector3 heading
    {
        get { return rigidBody.velocity.normalized; }
    }
}
