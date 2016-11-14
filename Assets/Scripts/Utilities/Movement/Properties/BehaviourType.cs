// Marc King - mjking@umich.edu

/// <summary>
/// Represents a type of movement behaviour.
/// </summary>
public enum BehaviourType
{
    /// <summary>
    /// Mover sits idle and does not move.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Idle,

    /// <summary>
    /// Mover attempts to move toward a transform.
    /// </summary>
    /// <remarks>
    /// Uses Radius as an arrival radius.
    /// </remarks>
    Seek,

    /// <summary>
    /// Mover attempts to move away from a transform.
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
    /// Mover attempts to catch a target transform.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Pursue,

    /// <summary>
    /// Mover attempts to prevent a target transform from catching it.
    /// </summary>
    /// <remarks>
    /// Does not use Radius.
    /// </remarks>
    Evade,

    /// <summary>
    /// Mover attempts to go around a target transform while moving.
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