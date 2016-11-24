// Marc King - mjking@umich.edu

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


    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        //Debug.Log("Pursue steering called.");
        //if (Deleting()) return parentBehaviour.Steering();
        //Debug.DrawRay(agentProperties.CurrentPosition, behaviour.Position - agentProperties.CurrentPosition, Color.yellow);
        //Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity, Color.green);

        var position = CalculateFuturePosition(agent.target.direct);

        //Debug.DrawRay(agentProperties.CurrentPosition, position - agentProperties.CurrentPosition, Color.magenta);

        var velocity = position - agent.position;
        var distance = velocity.magnitude;
        velocity = velocity.normalized * agent.mover.maxVelocity;

        //Debug.DrawRay(agentProperties.CurrentPosition, velocity, Color.red);

        if (distance < behaviour.distance * 2)
            velocity *= ((distance - behaviour.distance) / behaviour.distance);

        var steering = (velocity - agent.mover.velocity) * behaviour.priority;

        //Debug.DrawRay(agentProperties.CurrentPosition, steering, Color.blue);

        return steering + parentBehaviour.Steering();
    }



  

    /// <summary>
    /// Calculates the future position of the target based on its current velocity.
    /// </summary>
    /// <returns>Vector3 position in world space.</returns>
    private Vector3 CalculateFuturePosition(AgentManager target)
    {
        var prediction = target.mover.velocity * Time.fixedDeltaTime * behaviour.prediction;
        prediction *= (Vector3.Distance(target.position, agent.position) / agent.mover.maxVelocity);
        
        var position = target.position + prediction;
        
        return position;
    }

  

    private bool Deleting()
    {
        return DeleteIfTargetNull();
    }
}
