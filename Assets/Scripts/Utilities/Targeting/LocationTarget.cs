// Marc King - mjking@umich.edu

using System;
using UnityEngine;

/// <summary>
/// Represents a targeted location in space.
/// </summary>
public class LocationTarget : Target
{
    /// <summary>
    /// The location that has been targeted.
    /// </summary>
    public Vector3 location = Vector3.zero;

    public LocationTarget(Vector3 position)
    {
        this.location = position;
        this.type = TargetType.Location;
    }

    /// <summary>
    /// The position of the target location.
    /// </summary>
    public override Vector3 position
    {
        get
        {
            return location;
        }
    }
}
