// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to flee the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class FleeBehaviourDecorator : TargetBehaviourDecorator
{


    new FleeBehaviour behaviour;

    /// <summary>
    /// Constructor for flee behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public FleeBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as FleeBehaviour; }


    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        if (Deleting()) return parentBehaviour.Steering();

        var velocity = agent.position - behaviour.target.position;
        velocity = velocity.normalized * agent.mover.maxSpeed;

        var steering = (velocity - agent.mover.velocity) * behaviour.priority;

        return steering + parentBehaviour.Steering();
    }



    private bool Deleting()
    {
        if (DeleteIfTargetNull() || (behaviour.deleteWhenOutOfRange && HasFled()))
        {
            behaviour.OnDeleteBehaviour();
            return true;
        }
        return false;
    }

    private bool HasFled()
    {
        var distance = (behaviour.target.position - agent.position).magnitude;
        if (distance > behaviour.distance) return true;
        return false;
    }
}