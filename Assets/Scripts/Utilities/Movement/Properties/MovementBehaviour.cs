// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Delegate signature for methods to handle behaviour deletion events.
/// </summary>
/// <param name="behaviour"></param>
public delegate void DeleteBehaviourHandler(MovementBehaviour behaviour);

/// <summary>
/// Stores information about a movement behaviour that will be applied to a mover.
/// </summary>
//[System.Serializable]
public abstract class MovementBehaviour
{
    #region Events

    public event DeleteBehaviourHandler DeletingBehaviour;

    #endregion Events

    #region Inspector Fields

    [Header("General Properties")]

    [SerializeField]
    [Tooltip("The priority of this behaviour. Higher values make a behaviour impact movement more. " +
        "A value of 1.0 is considered standard priority.")]
    [Range(0.1f, 10.0f)]
    private float priority = 1.0f;

    #endregion Inspector Fields

    #region Private Fields

    protected BehaviourType type;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// The <see cref="BehaviourType"/> of this behaviour.
    /// </summary>
    public BehaviourType Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    /// <summary>
    /// The weighted strength of this behaviour. A value of <code>1.0</code> is considered standard weighting.
    /// </summary>
    public float Priority
    {
        get
        {
            return priority;
        }

        set
        {
            priority = value;
        }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Invokes the DeletingBehaviour event.
    /// </summary>
    public void OnDeleteBehaviour()
    {
        if (DeletingBehaviour != null) DeletingBehaviour(this);
    }

    #endregion Public Methods
}