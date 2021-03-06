﻿// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to evade the transform target.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class EvadeBehaviourDecorator : ActiveBehaviourDecorator
{


    /// <summary>
    /// Constructor for evade behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public EvadeBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour)
    {
        this.behaviour = behaviour as EvadeBehaviour;
        this.agent = parentBehaviour.agent;
    }





    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        //if (Deleting()) return parentBehaviour.Steering();

        var position = CalculateFuturePosition();

        var velocity = agent.position - position;
        velocity = velocity.normalized * agent.mover.maxSpeed;

        var steering = (velocity - agent.mover.velocity) * behaviour.priority;

        return steering + parentBehaviour.Steering();
    }


    /// <summary>
    /// Calculates the future position of the target based on its current velocity.
    /// </summary>
    /// <returns>Vector3 position in world space.</returns>
    private Vector3 CalculateFuturePosition()
    {
        // var targetMover = behaviour.Transform.gameObject.GetComponent<StandardMover>();
        // var prediction = targetMover.CurrentVelocity * Time.fixedDeltaTime * behaviour.PursuePrediction;
        // prediction *= (Vector3.Distance(behaviour.Position, moverProperties.currentPosition) / moverProperties.maximumSpeed);
        // var position = behaviour.Transform.position + prediction;
        // return position;
        return Vector3.zero;
    }


}
