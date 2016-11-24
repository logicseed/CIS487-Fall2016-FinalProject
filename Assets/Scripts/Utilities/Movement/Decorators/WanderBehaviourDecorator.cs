// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to wander.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class WanderBehaviourDecorator : ActiveBehaviourDecorator
{
    new WanderBehaviour behaviour;

    /// <summary>
    /// Constructor for wander behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public WanderBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour)
    {
        this.behaviour = behaviour as WanderBehaviour;
    }

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        if (Deleting()) return parentBehaviour.Steering();


        //if (moverProperties.CurrentVelocity == Vector3.zero)
        //    moverProperties.CurrentVelocity = moverProperties.CurrentHeading * moverProperties.MaximumSteering;
        //Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity, Color.green);

        var center = Vector3.ClampMagnitude(
            agent.mover.heading * agent.mover.maxVelocity,
            agent.mover.maxVelocity * behaviour.rate
        );

        if (center == Vector3.zero) center = Vector3.forward * agent.mover.maxSteering;

        //Debug.DrawRay(agentProperties.CurrentPosition, center, Color.red);

        var steering = Vector3.forward * behaviour.magnitude;

        var rotation = Quaternion.AngleAxis(behaviour.angle, Vector3.up);
        steering = ((center + (rotation * steering)) - agent.mover.velocity) * behaviour.priority;

        //var newWanderAngle = (Random.value * behaviour.AngleChange) - (behaviour.AngleChange * 0.5f);
        var newWanderAngle = Random.value * behaviour.angleChange - behaviour.angleChange * 0.5f;

        behaviour.angle += newWanderAngle;

        //steering = steering / 100;
        //Debug.DrawRay(agentProperties.CurrentPosition, steering, Color.blue);

        return steering + parentBehaviour.Steering();

    }

    private bool Deleting()
    {
        if (behaviour.time != -1.0f)
        {
            if (behaviour.time > 0.0f) behaviour.time -= Time.fixedDeltaTime;
            if (behaviour.time < 0.0f && behaviour.time >= -1.0f)
            {
                behaviour.OnDeleteBehaviour();
                return true;
            }
        }
        return false;
    }
}
