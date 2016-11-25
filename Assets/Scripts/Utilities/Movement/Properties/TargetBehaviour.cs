// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Parent behaviour for behaviour that has a Transform as a target.
/// </summary>
//[System.Serializable]
public abstract class TargetBehaviour : MovementBehaviour
{
    /// <summary>
    /// The Transform that will be the target of this movement behaviour.
    /// </summary>
    public AgentManager target = null;

    /// <summary>
    /// Whether or not this behaviour should be removed when the Transform becomes null.
    /// </summary>
    public bool deleteWhenNull = true;



    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetAgent">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public TargetBehaviour(AgentManager target, bool deleteWhenNull = true)
    {
        this.target = target;
        this.deleteWhenNull = deleteWhenNull;
    }
}
