// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents a object that has been targeted by an agent.
/// </summary>
public abstract class Target
{
    /// <summary>
    /// The type of target.
    /// </summary>
    public TargetType type = TargetType.None;

    /// <summary>
    /// The GameObject displaying the targeting indicator for this target.
    /// </summary>
    public GameObject graphicGameObject = null;

    /// <summary>
    /// The position of the target.
    /// </summary>
    public abstract Vector3 position { get; }

    /// <summary>
    /// The transform of the target.
    /// </summary>
    public virtual Transform transform
    {
        get
        {
            return null;
        }
    }
}
