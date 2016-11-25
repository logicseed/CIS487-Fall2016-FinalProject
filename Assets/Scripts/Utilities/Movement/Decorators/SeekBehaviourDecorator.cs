// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to seek the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class SeekBehaviourDecorator : TargetBehaviourDecorator
{
    new SeekBehaviour behaviour;

    /// <summary>
    /// Constructor for seek behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public SeekBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as SeekBehaviour; }

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        if (Deleting()) return parentBehaviour.Steering();
        
        var velocityVector = behaviour.target.position - agent.position;
        var desiredVelocity = velocityVector.normalized * agent.mover.maxVelocity;

        var distance = velocityVector.magnitude;
        if (distance < behaviour.approachRadius)
            desiredVelocity *= (distance / behaviour.approachRadius);

        var steering = (desiredVelocity - agent.mover.velocity);
        var prioritySteering = steering * behaviour.priority;

        if (debugRays)
        {
            Debug.DrawRay(agent.position, velocityVector, RayColor.Grey);
            Debug.DrawRay(agent.position + agent.mover.velocity,
                          prioritySteering, RayColor.Grey);

            Debug.DrawRay(agent.position, desiredVelocity, RayColor.Standard.SeekDesiredVelocity);
            Debug.DrawRay(agent.position + agent.mover.velocity,
                          steering, RayColor.Standard.SeekSteering);
        }

        return steering + parentBehaviour.Steering(debugRays);
    }

    private bool HasArrived()
    {
        var distance = (agent.target.location.position - agent.position).magnitude;

        if (distance < behaviour.arrivedRadius) return true;
        return false;
    }

    public bool Deleting()
    {
        if (DeleteIfTargetNull() || (behaviour.deleteUponArrived && HasArrived()))
        {
            behaviour.OnDeleteBehaviour();
            return true;
        }
        return false;
    }
}