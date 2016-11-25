// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for a wander behaviour.
/// </summary>
[System.Serializable]
public class WanderBehaviour : MovementBehaviour
{
    [Header("Wander Properties")]

    [Tooltip("Seconds this mover should wander. Set to -1 for endless wandering.")]
    [Range(-1.0f, 600.0f)]
    public float time = -1.0f;

    [Tooltip("Percentage of maximum speed that the mover will tend to wander at.")]
    [Range(0.0f, 1.0f)]
    public float rate = 1.0f;

    [Tooltip("How severe of an angle wandering turns will be.")]
    [Range(0.0f, 90.0f)]
    public float angleChange = 30.0f;

    [Tooltip("How strong a wander turn will be; higher is more erratic.")]
    [Range(0.0f, 20.0f)]
    public float magnitude = 2.0f;

    [HideInInspector]
    public float angle = 0.0f;
    [HideInInspector]
    public int skip = 10;


    public WanderBehaviour()
    {
        this.type = BehaviourType.Wander;
    }
}
