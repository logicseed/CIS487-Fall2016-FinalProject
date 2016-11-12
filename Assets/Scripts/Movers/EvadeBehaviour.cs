// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to evade the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class EvadeBehaviour : ActiveBehaviour
{
#region Constructor

    /// <summary>
    /// Constructor for evade behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public EvadeBehaviour(AbstractBehaviour parentBehaviour, MovementBehaviour behaviour) 
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

        var position = CalculateFuturePosition();

        var velocity = moverProperties.currentPosition - position;
        velocity = velocity.normalized * moverProperties.maximumSpeed;

        var steering = velocity - moverProperties.currentVelocity;

        return steering + parentBehaviour.Steering();
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Calculates the future position of the target based on its current velocity.
    /// </summary>
    /// <returns>Vector3 position in world space.</returns>
    private Vector3 CalculateFuturePosition()
    {
        var targetMover = behaviour.Transform.gameObject.GetComponent<StandardMover>();
        var prediction = targetMover.CurrentVelocity * Time.fixedDeltaTime * behaviour.PursuePrediction;
        prediction *= (Vector3.Distance(behaviour.Position, moverProperties.currentPosition) / moverProperties.maximumSpeed);
        var position = behaviour.Transform.position + prediction;
        return position;
    }

    #endregion Private Methods
}
