// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for a flee behaviour.
/// </summary>
[System.Serializable]
public class FleeBehaviour : TargetBehaviour
{
    #region Inspector Fields

    [Header("Flee Properties")]

    [SerializeField]
    [Range(5.0f, 20.0f)]
    [Tooltip("Distance from target at which the mover will be considered to have fled. Measured in Unity units.")]
    private float distance = 20.0f;

    [SerializeField]
    [Tooltip("Whether or not this behaviour will be deleted after fleeing farther than the distance.")]
    private bool deleteWhenOutOfRange = true;

    #endregion Inspector Fields

    #region Constructors

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public FleeBehaviour(Transform targetTransform, bool deleteWhenNull = true) 
    : base (targetTransform, deleteWhenNull) { type = BehaviourType.Flee; }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// Distance from target at which the mover will be considered to have fled. Measured in Unity units.
    /// </summary>
    public float Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
        }
    }

    /// <summary>
    /// Whether or not this behaviour will be deleted after fleeing past the <see cref="Distance"/>.
    /// </summary>
    public bool DeleteWhenOutOfRange
    {
        get
        {
            return deleteWhenOutOfRange;
        }

        set
        {
            deleteWhenOutOfRange = value;
        }
    }

    #endregion Public Properties
}
