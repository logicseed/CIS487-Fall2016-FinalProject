// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties for an idle behaviour.
/// </summary>
[System.Serializable]
public class IdleBehaviour : MovementBehaviour
{
    [Header("Idle Properties")]

    [SerializeField]
    [Tooltip("Whether or not the mover will brake to a stop in order to be considered idle.")]
    private bool braking = true;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public IdleBehaviour() { Priority = 0.01f; type = BehaviourType.Idle; }

    /// <summary>
    /// Whether or not the mover will brake to a stop in order to be considered idle.
    /// </summary>
    public bool Braking
    {
        get
        {
            return braking;
        }

        set
        {
            braking = value;
        }
    }
}
