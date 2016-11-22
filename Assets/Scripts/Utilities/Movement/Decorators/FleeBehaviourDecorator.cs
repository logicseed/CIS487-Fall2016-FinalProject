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
    #region Constructor

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

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        if (Deleting()) return parentBehaviour.Steering();

        var velocity = agentProperties.CurrentPosition - behaviour.Position;
        velocity = velocity.normalized * agentProperties.MaximumSpeed;

        var steering = (velocity - agentProperties.CurrentVelocity) * behaviour.Priority;

        return steering + parentBehaviour.Steering();
    }

    #endregion Public Methods

    private bool Deleting()
    {
        if (DeleteIfTargetNull() || (behaviour.DeleteWhenOutOfRange && HasFled()))
        {
            behaviour.OnDeleteBehaviour();
            return true;
        }
        return false;
    }

    private bool HasFled()
    {
        var distance = (behaviour.Position - agentProperties.CurrentPosition).magnitude;
        if (distance > behaviour.Distance) return true;
        return false;
    }
}