// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to flee the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class FleeBehaviour : ActiveBehaviour
{
    #region Constructor

    /// <summary>
    /// Constructor for flee behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public FleeBehaviour(AbstractBehaviour parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering()
    {
        if (Deleting()) return parentBehaviour.Steering();

        var velocity = moverProperties.currentPosition - behaviour.Position;
        var distance = velocity.magnitude;
        velocity = velocity.normalized * moverProperties.maximumSpeed;

        var steering = velocity - moverProperties.currentVelocity;

        return steering + parentBehaviour.Steering();
    }

    #endregion Public Methods
}