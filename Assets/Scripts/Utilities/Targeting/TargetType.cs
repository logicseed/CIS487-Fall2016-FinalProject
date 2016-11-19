// Marc King - mjking@umich.edu

/// <summary>
/// Represents the type of the target stored by the target manager.
/// </summary>
public enum TargetType
{
    /// <summary>
    /// Something must have gone wrong.
    /// </summary>
    None,

    /// <summary>
    /// Target is a position in space.
    /// </summary>
    Location,

    /// <summary>
    /// Target is an ally.
    /// </summary>
    Ally,

    /// <summary>
    /// Target is an enemy.
    /// </summary>
    Enemy,

    /// <summary>
    /// Target is a world object that has been captured.
    /// </summary>
    AllyCapture,

    /// <summary>
    /// Target is a world object that can be captured.
    /// </summary>
    EnemyCapture
}
