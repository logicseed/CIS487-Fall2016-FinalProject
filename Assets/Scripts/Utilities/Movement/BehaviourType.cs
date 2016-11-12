// Marc King - mjking@umich.edu

/// <summary>
/// Represents a type of movement behaviour.
/// </summary>
public enum MovementType
{
    /// <summary>
    /// Mover sits idle and does not move.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Idle,

    /// <summary>
    /// Mover attempts to move toward a position.
    /// </summary>
    /// <remarks>
    /// Uses Radius as an arrival radius.
    /// </remarks>
    Seek,

    /// <summary>
    /// Mover attempts to move away from a position.
    /// </summary>
    /// <remarks>
    /// Uses Radius as an escape distance.
    /// </remarks>
    Flee,

    /// <summary>
    /// Mover attempts to move in random directions.
    /// </summary>
    /// <remarks>
    /// Uses Radius as wander distance.
    /// </remarks>
    Wander,

    /// <summary>
    /// Mover attempts to catch a target.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Pursue,

    /// <summary>
    /// Mover attempts to prevent a target from catching it.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Evade,

    /// <summary>
    /// Mover attempts to go around a target while moving.
    /// </summary>
    /// <remarks>
    /// Uses Radius as avoidance distance.
    /// </remarks>
    Avoid,

    /// <summary>
    /// Mover attempts to enter a circular path around target.
    /// </summary>
    /// <remarks>
    /// Uses Radius as orbital distance.
    /// </remarks>
    Orbit
}