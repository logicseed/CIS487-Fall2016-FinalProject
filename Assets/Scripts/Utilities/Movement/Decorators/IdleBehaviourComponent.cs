﻿// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents the idle movement behaviour.
/// </summary>
/// <remarks>
/// ConcreteComponent of the Decorator pattern.
/// </remarks>
public class IdleBehaviourComponent : AbstractBehaviourComponent
{
    protected AgentProperties agentProperties;
    protected IdleBehaviour behaviourProperties;



    /// <summary>
    /// Constructor for idle movement behaviour.
    /// </summary>
    /// <param name="agentProperties">
    /// MovementProperties of the attached mover.
    /// </param>
    /// <param name="behaviourProperties">
    /// MovementBehaviour details for this behaviour.
    /// </param>
    public IdleBehaviourComponent(AgentProperties agentProperties, MovementBehaviour behaviourProperties)
    {
        this.agentProperties = agentProperties;
        this.behaviourProperties = behaviourProperties as IdleBehaviour;
    }



    /// <summary>
    /// Gets the properties of the mover to which this behaviour is attached.
    /// </summary>
    /// <returns>MovementProperties of the mover.</returns>
    public override AgentProperties Properties()
    {
        return agentProperties;
    }

    /// <summary>
    /// Calculates the new velocity of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 velocity based on movement behaviour.</returns>
    public override Vector3 NewVelocity()
    {
        var acceleration = agentProperties.CurrentVelocity.magnitude - agentProperties.MaximumSteering;
        acceleration = Mathf.Max(0.0f, acceleration);
        return agentProperties.CurrentVelocity.Truncate(acceleration);
    }

    /// <summary>
    /// Calculates the steering vector of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 steering vector of idle behaviour.</returns>
    public override Vector3 Steering(bool debugRays = false)
    {
        if (behaviourProperties.Braking)
        {
            var steering = Vector3.ClampMagnitude(-agentProperties.CurrentVelocity, agentProperties.MaximumSteering);
            return steering;
        }
        return Vector3.zero;
    }
}
