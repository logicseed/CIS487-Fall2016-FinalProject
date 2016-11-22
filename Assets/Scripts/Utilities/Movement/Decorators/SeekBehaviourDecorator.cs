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
        
        var velocityVector = behaviour.Position - agentProperties.CurrentPosition;
        var desiredVelocity = velocityVector.normalized * agentProperties.MaximumSpeed;

        var distance = velocityVector.magnitude;
        if (distance < behaviour.SlowApproachRadius)
            desiredVelocity *= (distance / behaviour.SlowApproachRadius);

        var steering = (desiredVelocity - agentProperties.CurrentVelocity);
        var prioritySteering = steering * behaviour.Priority;

        if (debugRays)
        {
            Debug.DrawRay(agentProperties.CurrentPosition, velocityVector, RayColor.Grey);
            Debug.DrawRay(agentProperties.CurrentPosition + agentProperties.CurrentVelocity,
                          prioritySteering, RayColor.Grey);

            Debug.DrawRay(agentProperties.CurrentPosition, desiredVelocity, RayColor.Standard.SeekDesiredVelocity);
            Debug.DrawRay(agentProperties.CurrentPosition + agentProperties.CurrentVelocity,
                          steering, RayColor.Standard.SeekSteering);
        }

        return steering + parentBehaviour.Steering(debugRays);
    }

    private bool HasArrived()
    {
        var distance = (behaviour.Position - agentProperties.CurrentPosition).magnitude;

        if (distance < behaviour.ArrivedRadius) return true;
        return false;
    }

    public bool Deleting()
    {
        if (DeleteIfTargetNull() || (behaviour.DeleteUponArrived && HasArrived()))
        {
            behaviour.OnDeleteBehaviour();
            return true;
        }
        return false;
    }
}