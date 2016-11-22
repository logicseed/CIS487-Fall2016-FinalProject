// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/// <summary>
/// Generic mover for all space-based objects that use <see cref="MovementBehaviour"/>s to move.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AgentManager))]
[DisallowMultipleComponent]
public class StandardMover : MonoBehaviour
{
    #region Inspector Fields

    /// <summary>
    /// Properties of the mover.
    /// </summary>
    [Tooltip("Movement properties of the mover.")]
    public AgentProperties props;

    /// <summary>
    /// GameObject reference to the graphical representation of this mover.
    /// </summary>
    [Tooltip("GameObject reference to the graphical representation of this mover.")]
    public Transform graphicsGameObject;

    #endregion Inspector Fields

    #region MonoBehaviour Methods

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        UpdateAgentProperties();
        UpdateGraphicsHeading();
        RemoveDeletedBehaviours();
    }

    #endregion MonoBehaviour Methods

    #region Private Fields

    private Rigidbody rigidBody;
    private List<MovementBehaviour> behaviours = new List<MovementBehaviour>();
    private List<MovementBehaviour> behavioursToRemove = new List<MovementBehaviour>();

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Updates <see cref="props"/> based on recent movement and behaviours.
    /// </summary>
    private void UpdateAgentProperties()
    {
        // true for debugging
        var debugRays = true;

        props.CurrentPosition = transform.position;

        props.CurrentVelocity = rigidBody.velocity;

        var prioritySteering = CalculateSteeringForce(debugRays);
        var steering = Vector3.ClampMagnitude(prioritySteering, props.MaximumSteering);

        rigidBody.AddForce(steering, ForceMode.VelocityChange);
        props.CurrentVelocity = rigidBody.velocity;

        if (props.CurrentVelocity != Vector3.zero)
            props.CurrentHeading = props.CurrentVelocity.normalized;

        if (debugRays)
        {
            // Unclamped acceleration
            Debug.DrawRay(props.CurrentPosition + props.CurrentVelocity,
                          prioritySteering, RayColor.Standard.UnclampedAcceleration);
            // Velocity vector
            Debug.DrawRay(props.CurrentPosition, props.CurrentVelocity, RayColor.Standard.Velocity);

            // Acceleration vector
            Debug.DrawRay(props.CurrentPosition + props.CurrentVelocity,
                          steering, RayColor.Standard.Acceleration);
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
        //Debug.Log("Number of behaviours: " + behaviours.Count);
        AbstractBehaviourComponent movementBehaviours = new IdleBehaviourComponent(props, new IdleBehaviour());

        var avoidB = new AvoidBehaviour();
        avoidB.Priority = 100.0f;
        movementBehaviours = new AvoidBehaviourDecorator(movementBehaviours, avoidB);

        foreach (var behaviour in behaviours)
        {
            switch (behaviour.Type)
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
            }
        }

        

        return movementBehaviours.Steering(debugRays);
    }

    /// <summary>
    /// Updates the <see cref="GameObject"/> that represent the graphics for this mover to face to correct heading for
    /// the mover's current velocity.
    /// </summary>
    private void UpdateGraphicsHeading()
    {
        if (graphicsGameObject != null)
        {
            //var heading = transform.position + movementProperties.CurrentHeading;
            //graphicsGameObject.LookAt(heading);
            var targetDir = rigidBody.velocity;
            var newDir = Vector3.RotateTowards(graphicsGameObject.transform.forward, targetDir, Time.fixedDeltaTime * 10, 0.0f);
            graphicsGameObject.rotation = Quaternion.LookRotation(newDir);
        }
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

    #endregion Private Methods

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="behaviour"></param>
    public void AddBehaviour(MovementBehaviour behaviour)
    {
        behaviour.DeletingBehaviour += new DeleteBehaviourHandler(RemoveBehaviour);
        behaviours.Add(behaviour);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="behaviour"></param>
    public void RemoveBehaviour(MovementBehaviour behaviour)
    {
        behavioursToRemove.Add(behaviour);
    }

    /// <summary>
    /// 
    /// </summary>
    public Vector3 CurrentVelocity
    {
        get
        {
            return props.CurrentVelocity;
        }
    }

    #endregion Public Methods
}
