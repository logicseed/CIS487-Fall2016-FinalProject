﻿// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to pursue the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class PursueBehaviourDecorator : TargetBehaviourDecorator
{
    new PursueBehaviour behaviour;

    #region Constructor

    /// <summary>
    /// Constructor for pursue behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public PursueBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as PursueBehaviour; }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering()
    {
        Debug.Log("Pursue steering called.");
        //if (Deleting()) return parentBehaviour.Steering();
        Debug.DrawRay(moverProperties.CurrentPosition, behaviour.Position - moverProperties.CurrentPosition, Color.yellow);
        Debug.DrawRay(moverProperties.CurrentPosition, moverProperties.CurrentVelocity, Color.green);

        var position = CalculateFuturePosition();

        Debug.DrawRay(moverProperties.CurrentPosition, position - moverProperties.CurrentPosition, Color.magenta);

        var velocity = position - moverProperties.CurrentPosition;
        var distance = velocity.magnitude;
        velocity = velocity.normalized * moverProperties.MaximumSpeed;

        Debug.DrawRay(moverProperties.CurrentPosition, velocity, Color.red);

        if (distance < behaviour.Distance * 2)
            velocity *= ((distance - behaviour.Distance) / behaviour.Distance);

        var steering = velocity - moverProperties.CurrentVelocity;

        Debug.DrawRay(moverProperties.CurrentPosition, steering, Color.blue);

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
        var targetMover = behaviour.TargetTransform.GetComponent<StandardMover>();

        

        var prediction = targetMover.CurrentVelocity * Time.fixedDeltaTime * behaviour.Prediction;
        prediction *= (Vector3.Distance(behaviour.Position, moverProperties.CurrentPosition) / moverProperties.MaximumSpeed);
        
        var position = behaviour.TargetTransform.position + prediction;
        
        return position;
    }

    #endregion Private Methods

    private bool Deleting()
    {
        return DeleteIfTargetNull();
    }
}