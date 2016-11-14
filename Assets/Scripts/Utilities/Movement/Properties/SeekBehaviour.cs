// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties for a seek behaviour.
/// </summary>
[System.Serializable]
public class SeekBehaviour : TargetBehaviour
{
    #region Inspector Fields

    [Header("Arrival Properties")]

    [SerializeField]
    [Tooltip("Distance from target at which mover will begin slowing down. Measured in Unity units.")]
    [Range(0.5f, 10.0f)]
    private float slowApproachRadius = 3.0f;

    [SerializeField]
    [Tooltip("Distance from target when mover will consider to have arrived at the target. Measured in Unity units.")]
    [Range(0.5f, 10.0f)]
    private float arrivedRadius = 0.5f;

    [SerializeField]
    [Tooltip("Whether or not this behaviour should be deleted after arriving at the target.")]
    private bool deleteUponArrived = true;

    #endregion Inspector Fields

    #region Private Fields

    //public readonly BehaviourType Type = BehaviourType.Seek;

    #endregion Private Fields

    #region Constructors

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public SeekBehaviour(Transform targetTransform, bool deleteWhenNull = true) 
    : base (targetTransform, deleteWhenNull) { type = BehaviourType.Seek; }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// Distance from target at which mover will begin slowing down. Measured in Unity units.
    /// </summary>
    public float SlowApproachRadius
    {
        get
        {
            return slowApproachRadius;
        }

        set
        {
            slowApproachRadius = value;
        }
    }

    /// <summary>
    /// Distance from target at which the mover will be considered to have arrived. Measured in Unity units.
    /// </summary>
    public float ArrivedRadius
    {
        get
        {
            return arrivedRadius;
        }

        set
        {
            arrivedRadius = value;
        }
    }

    /// <summary>
    /// /// Whether or not this behaviour will be deleted upon coming within <see cref="ArrivedRadius"/> of its target.
    /// </summary>
    public bool DeleteUponArrived
    {
        get
        {
            return deleteUponArrived;
        }

        set
        {
            deleteUponArrived = value;
        }
    }

    #endregion Public Properties
}
