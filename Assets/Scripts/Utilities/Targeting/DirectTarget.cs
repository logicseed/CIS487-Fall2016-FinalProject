// Marc King - mjking@umich.edu

using System;
using UnityEngine;

/// <summary>
/// Represents a targeted agent.
/// </summary>
public class DirectTarget : Target
{
    /// <summary>
    /// The GameObject that has been targeted.
    /// </summary>
    public GameObject gameObject = null;

    public DirectTarget(TargetType type, GameObject target)
    {
        this.type = type;
        this.gameObject = target;
    }

    /// <summary>
    /// The position of the target.
    /// </summary>
    public override Vector3 position
    {
        get
        {
            return gameObject.transform.position;
        }
    }

    /// <summary>
    /// The transform of the target.
    /// </summary>
    public override Transform transform
    {
        get
        {
            return gameObject.transform;
        }
    }
}
