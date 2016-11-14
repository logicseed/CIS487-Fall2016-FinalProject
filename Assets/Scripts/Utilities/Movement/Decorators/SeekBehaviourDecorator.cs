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

    #region Constructor

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

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering()
    {
        if (Deleting()) return parentBehaviour.Steering();
        
        Debug.DrawRay(moverProperties.CurrentPosition, behaviour.Position - moverProperties.CurrentPosition, Color.yellow);

        Debug.DrawRay(moverProperties.CurrentPosition, moverProperties.CurrentVelocity, Color.green);
        
        var velocity = behaviour.Position - moverProperties.CurrentPosition;
        var distance = velocity.magnitude;
        velocity = velocity.normalized * moverProperties.MaximumSpeed;

        if (distance < behaviour.SlowApproachRadius)
            velocity *= (distance / behaviour.SlowApproachRadius);
        
        Debug.DrawRay(moverProperties.CurrentPosition, velocity, Color.red);

        var steering = velocity - moverProperties.CurrentVelocity;

        Debug.DrawRay(moverProperties.CurrentPosition, steering, Color.blue);

        return steering + parentBehaviour.Steering();
    }

    #endregion Public Methods

    private bool HasArrived()
    {
        var distance = (behaviour.Position - moverProperties.CurrentPosition).magnitude;

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