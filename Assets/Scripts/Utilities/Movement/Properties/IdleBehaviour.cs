// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties for an idle behaviour.
/// </summary>
[System.Serializable]
public class IdleBehaviour : MovementBehaviour
{
    /// <summary>
    /// Whether or not the mover will brake to a stop in order to be considered idle.
    /// </summary>
    public bool activeBraking = true;

    public IdleBehaviour(float priority, bool activeBraking = true)
    {
        this.priority = priority;
        this.type = BehaviourType.Idle;
        this.activeBraking = activeBraking;
    }

    public IdleBehaviour(bool activeBraking = true)
    {
        this.priority = 0.01f;
        this.type = BehaviourType.Idle;
        this.activeBraking = activeBraking;
    }
}
