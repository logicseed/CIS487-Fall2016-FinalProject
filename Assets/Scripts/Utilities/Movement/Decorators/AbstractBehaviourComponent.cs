// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents the base movement behaviour from which all other movement behaviours are derived.
/// </summary>
/// <remarks>
/// Abstract Component of the Decorator pattern.
/// </remarks>
public abstract class AbstractBehaviourComponent
{
    #region Abstract Methods

    /// <summary>
    /// Gets the properties of the mover to which this behaviour is attached.
    /// </summary>
    /// <returns>MovementProperties of the mover.</returns>
    public abstract AgentProperties Properties();

    /// <summary>
    /// Calculates a new velocity based on all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 velocity based on movement behaviour.</returns>
    public abstract Vector3 NewVelocity();

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public abstract Vector3 Steering();

    #endregion Abstract Methods
}