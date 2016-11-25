// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties for a seek behaviour.
/// </summary>
public class SeekBehaviour : TargetBehaviour
{
    /// <summary>
    /// Distance from target at which mover will begin slowing down. Measured in Unity units.
    /// </summary>
    public float approachRadius = 3.0f;

    /// <summary>
    /// Distance from target when mover will consider to have arrived at the target. Measured in Unity units.
    /// </summary>
    public float arrivedRadius = 0.5f;

    /// <summary>
    /// Whether or not this behaviour should be deleted after arriving at the target.
    /// </summary>
    public bool deleteUponArrived = true;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="target">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public SeekBehaviour(AgentManager target, bool deleteWhenNull = true) 
    : base (target, deleteWhenNull) { type = BehaviourType.Seek; }
}
