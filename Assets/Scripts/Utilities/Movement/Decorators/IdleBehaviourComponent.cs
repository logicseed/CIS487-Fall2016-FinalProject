// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents the idle movement behaviour.
/// </summary>
/// <remarks>
/// ConcreteComponent of the Decorator pattern.
/// </remarks>
public class IdleBehaviourComponent : AbstractBehaviourComponent
{
    public IdleBehaviour behaviour;

    public IdleBehaviourComponent(AgentManager agent, MovementBehaviour behaviour)
    {
        this.agent = agent;
        this.behaviour = behaviour as IdleBehaviour;
    }

    /// <summary>
    /// Calculates the steering vector of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 steering vector of idle behaviour.</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        //Debug.Log("Agent: " + agent);
        //Debug.Log("Behaviour: " + behaviour);
        if (behaviour.activeBraking)
        {
            var steering = Vector3.ClampMagnitude(-agent.mover.velocity, agent.mover.maxSteering);
            return steering;
        }
        return Vector3.zero;
    }
}
