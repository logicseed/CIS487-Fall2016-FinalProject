// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Parent behaviour for behaviour that has a Transform as a target.
/// </summary>
//[System.Serializable]
public abstract class TargetBehaviour : MovementBehaviour
{
    #region Inspector Fields

    [Header("Target Properties")]

    [SerializeField]
    [Tooltip("The Transform that will be the target of this movement behaviour.")]
    protected Transform targetTransform = null;

    [SerializeField]
    [Tooltip("Whether or not this behaviour should be removed when the Transform becomes null.")]
    protected bool deleteWhenNull = true;

    #endregion Inspector Fields

    #region Constructors

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public TargetBehaviour(Transform targetTransform, bool deleteWhenNull = true)
    {
        this.targetTransform = targetTransform;
        this.deleteWhenNull = deleteWhenNull;
    }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// The target for this behaviour.
    /// </summary>
    public Transform TargetTransform
    {
        get
        {
            return targetTransform;
        }

        set
        {
            targetTransform = value;
        }
    }

    /// <summary>
    /// The world space position of the target of this behaviour.
    /// </summary>
    public Vector3 Position
    {
        get
        {
            return TargetTransform.position;
        }
    }

    /// <summary>
    /// Whether or not this behaviour will be deleted if its target becomes <code>null</code>.
    /// </summary>
    public bool DeleteWhenNull
    {
        get
        {
            return deleteWhenNull;
        }

        set
        {
            deleteWhenNull = value;
        }
    }

    #endregion Public Properties
}
