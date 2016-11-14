// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties of a GameObject with a StandardMover script attached.
/// </summary>
[System.Serializable]
public class MoverProperties
{
    #region Inspector Fields

    [SerializeField]
    [Tooltip("The maximum speed that this mover can attain.")]
    //[Range(0.5f, 50.0f)]
    private float maximumSpeed = 15.0f;

    [SerializeField]
    [Tooltip("The maximum steering that can modify this mover's velocity.")]
    //[Range(0.05f, 5.0f)]
    private float maximumSteering = 1.0f;

    [SerializeField]
    [Tooltip("The mass of the mover.")]
    //[Range(0.0f, 1000.0f)]
    private float moverMass = 0.0f;

    #endregion Inspector Fields
    #region Private Fields
    #endregion Private Fields
    #region Constructors
    #endregion Constructors
    #region Public Properties
    #endregion Public Properties
    private Vector3 currentVelocity;
    private Vector3 currentPosition;
    private Vector3 currentHeading;

    

    /// <summary>
    /// Current local space velocity vector of this mover.
    /// </summary>
    public Vector3 CurrentVelocity
    {
        get
        {
            return currentVelocity;
        }

        set
        {
            currentVelocity = value;
        }
    }

    /// <summary>
    /// Current world space position of this mover.
    /// </summary>
    public Vector3 CurrentPosition
    {
        get
        {
            return currentPosition;
        }

        set
        {
            currentPosition = value;
        }
    }

    /// <summary>
    /// Direction of the current velocity.
    /// </summary>
    public Vector3 CurrentHeading
    {
        get
        {
            return currentHeading;
        }

        set
        {
            currentHeading = value;
        }
    }

    /// <summary>
    /// The maximum speed that this mover can attain.
    /// </summary>
    public float MaximumSpeed
    {
        get
        {
            return maximumSpeed;
        }

        set
        {
            maximumSpeed = value;
        }
    }

    /// <summary>
    /// The maximum steering that can modify this mover's velocity.
    /// </summary>
    public float MaximumSteering
    {
        get
        {
            return maximumSteering;
        }

        set
        {
            maximumSteering = value;
        }
    }

    /// <summary>
    /// The mass of the mover.
    /// </summary>
    public float MoverMass
    {
        get
        {
            return moverMass;
        }

        set
        {
            moverMass = value;
        }
    }


}