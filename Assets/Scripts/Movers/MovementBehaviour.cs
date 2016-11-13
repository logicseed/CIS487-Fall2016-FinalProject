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
public class MovementBehaviour
{
    #region Events

    public event DeleteBehaviourHandler DeletingBehaviour;

    #endregion Events

    #region Private Fields

    private MovementType type = MovementType.Idle;
    private Transform transform = null;
    private Vector3 position = Vector3.zero;
    private float strength = 1.0f;
    private bool deleteUponArrived = true;
    private bool deleteAfterFlee = true;
    private bool deleteTransformNull = true;
    private float arrivalRadius = 3.0f;
    private float arrivedRadius = 0.5f;
    private float fleeRadius = 20.0f;
    private float orbitRadius = 10.0f;
    private float wanderRate = 1.0f;
    private float wanderMagnitude = 2.0f;
    private float wanderAngle = 0.0f;
    private float wanderAngleChange = 30.0f;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// The <see cref="MovementType"/> of this behaviour.
    /// </summary>
    public MovementType Type
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
    /// The target <see cref="Transform"/> for this behaviour.
    /// </summary>
    public Transform Transform
    {
        get
        {
            return transform;
        }

        set
        {
            transform = value;
        }
    }

    /// <summary>
    /// The world space position of the target of this behaviour.
    /// </summary>
    public Vector3 Position
    {
        get
        {
            if (Transform == null) return position;
            return Transform.position;
        }
        set
        {
            position = value;
        }
    }

    /// <summary>
    /// The weighted strength of this behaviour. A value of <code>1.0</code> is considered standard weighting.
    /// </summary>
    public float Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    /// <summary>
    /// Whether or not this behaviour will be deleted upon coming within <see cref="ArrivedRadius"/> of its target.
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

    /// <summary>
    /// Whether or not this behaviour will be deleted after fleeing past the <see cref="FleeRadius"/>.
    /// </summary>
    public bool DeleteAfterFlee
    {
        get
        {
            return deleteAfterFlee;
        }

        set
        {
            deleteAfterFlee = value;
        }
    }

    /// <summary>
    /// Whether or not this behaviour will be deleted if its <see cref="Transform"/> target becomes <code>null</code>.
    /// </summary>
    public bool DeleteTransformNull
    {
        get
        {
            return deleteTransformNull;
        }

        set
        {
            deleteTransformNull = value;
        }
    }

    /// <summary>
    /// Distance from target at which mover will begin to slow down. Measured in Unity units.
    /// </summary>
    public float ArrivalRadius
    {
        get
        {
            return arrivalRadius;
        }

        set
        {
            arrivalRadius = value;
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
    /// Distance from target at which the mover will be considered to have fled. Measured in Unity units.
    /// </summary>
    public float FleeRadius
    {
        get
        {
            return fleeRadius;
        }

        set
        {
            fleeRadius = value;
        }
    }

    /// <summary>
    /// Distance from target at which the mover will attempt to orbit. Measured in Unity units.
    /// </summary>
    public float OrbitRadius
    {
        get
        {
            return orbitRadius;
        }

        set
        {
            orbitRadius = value;
        }
    }

    /// <summary>
    /// Percentage of MaximumVelocity that the mover will tend to wander at.
    /// </summary>
    public float WanderRate
    {
        get
        {
            return wanderRate;
        }

        set
        {
            wanderRate = value;
        }
    }

    /// <summary>
    /// Strength of steering while wandering; higher is more erratic.
    /// </summary>
    public float WanderMagnitude
    {
        get
        {
            return wanderMagnitude;
        }

        set
        {
            wanderMagnitude = value;
        }
    }

    /// <summary>
    /// Last angle used while wandering. SHOULD NOT SET.
    /// </summary>
    public float WanderAngle
    {
        get
        {
            return wanderAngle;
        }

        set
        {
            wanderAngle = value;
        }
    }

    /// <summary>
    /// The maximum change to WanderAngle during each update.
    /// </summary>
    public float WanderAngleChange
    {
        get
        {
            return wanderAngleChange;
        }

        set
        {
            wanderAngleChange = value;
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