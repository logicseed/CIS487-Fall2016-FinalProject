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
    #region Protected Fields

    protected AgentProperties moverProperties;
    protected IdleBehaviour behaviourProperties;

    #endregion Protected Fields

    #region Constructor

    /// <summary>
    /// Constructor for idle movement behaviour.
    /// </summary>
    /// <param name="moverProperties">
    /// MovementProperties of the attached mover.
    /// </param>
    /// <param name="behaviourProperties">
    /// MovementBehaviour details for this behaviour.
    /// </param>
    public IdleBehaviourComponent(AgentProperties moverProperties, MovementBehaviour behaviourProperties)
    {
        this.moverProperties = moverProperties;
        this.behaviourProperties = behaviourProperties as IdleBehaviour;
    }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Gets the properties of the mover to which this behaviour is attached.
    /// </summary>
    /// <returns>MovementProperties of the mover.</returns>
    public override AgentProperties Properties()
    {
        return moverProperties;
    }

    /// <summary>
    /// Calculates the new velocity of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 velocity based on movement behaviour.</returns>
    public override Vector3 NewVelocity()
    {
        var acceleration = moverProperties.CurrentVelocity.magnitude - moverProperties.MaximumSteering;
        acceleration = Mathf.Max(0.0f, acceleration);
        return moverProperties.CurrentVelocity.Truncate(acceleration);
    }

    /// <summary>
    /// Calculates the steering vector of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 steering vector of idle behaviour.</returns>
    public override Vector3 Steering()
    {
        //Debug.Log("Idle Steering called.");
        if (behaviourProperties.Braking)
        {
            var steering = Vector3.ClampMagnitude(-moverProperties.CurrentVelocity, moverProperties.MaximumSteering);
            return steering;
        }
        return Vector3.zero;
    }

    #endregion Public Methods
}
