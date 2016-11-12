// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents the idle movement behaviour.
/// </summary>
/// <remarks>
/// ConcreteComponent of the Decorator pattern.
/// </remarks>
public class IdleBehaviour : AbstractBehaviour
{
    #region Protected Fields

    protected MoverProperties moverProperties;
    protected MovementBehaviour behaviourProperties;

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
    public IdleBehaviour(MoverProperties moverProperties, MovementBehaviour behaviourProperties)
    {
        this.moverProperties = moverProperties;
        this.behaviourProperties = behaviourProperties;
    }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Gets the properties of the mover to which this behaviour is attached.
    /// </summary>
    /// <returns>MovementProperties of the mover.</returns>
    public override MoverProperties Properties()
    {
        return moverProperties;
    }

    /// <summary>
    /// Calculates the new velocity of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 velocity based on movement behaviour.</returns>
    public override Vector3 NewVelocity()
    {
        var acceleration = moverProperties.currentVelocity.magnitude - moverProperties.maximumSteering;
        acceleration = Mathf.Max(0.0f, acceleration);
        return moverProperties.currentVelocity.Truncate(acceleration);
    }

    /// <summary>
    /// Calculates the steering vector of the idle behaviour.
    /// </summary>
    /// <returns>Vector3 steering vector of idle behaviour.</returns>
    public override Vector3 Steering()
    {
        return Vector3.zero;
    }

    #endregion Public Methods
}
