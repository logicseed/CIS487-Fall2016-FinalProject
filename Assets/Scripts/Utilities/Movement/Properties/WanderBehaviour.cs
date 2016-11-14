// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for a wander behaviour.
/// </summary>
[System.Serializable]
public class WanderBehaviour : MovementBehaviour
{
    #region Inspector Fields

    [Header("Wander Properties")]

    [SerializeField]
    [Tooltip("Seconds this mover should wander. Set to -1 for endless wandering.")]
    [Range(-1.0f, 600.0f)]
    private float time = -1.0f;

    [SerializeField]
    [Tooltip("Percentage of maximum speed that the mover will tend to wander at.")]
    [Range(0.0f, 1.0f)]
    private float rate = 1.0f;

    [SerializeField]
    [Tooltip("How severe of an angle wandering turns will be.")]
    [Range(15.0f, 90.0f)]
    private float angleChange = 30.0f;

    [SerializeField]
    [Tooltip("How strong a wander turn will be; higher is more erratic.")]
    [Range(0.0f, 20.0f)]
    private float magnitude = 2.0f;

    #endregion Inspector Fields

    #region Private Fields

    private float angle = 0.0f;
    private int skip = 10;

    #endregion Private Fields

    #region Constructors

    public WanderBehaviour()
    {
        type = BehaviourType.Wander;
    }

    #endregion Constructors

    #region Public Properties

    /// <summary>
    /// Seconds this mover should wander. Set to -1 for endless wandering.
    /// </summary>
    public float Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
        }
    }

    /// <summary>
    /// Percentage of MaximumVelocity that the mover will tend to wander at.
    /// </summary>
    public float Rate
    {
        get
        {
            return rate;
        }

        set
        {
            rate = value;
        }
    }

    /// <summary>
    /// The maximum change to WanderAngle during each update.
    /// </summary>
    public float AngleChange
    {
        get
        {
            return angleChange;
        }

        set
        {
            angleChange = value;
        }
    }

    /// <summary>
    /// Strength of steering while wandering; higher is more erratic.
    /// </summary>
    public float Magnitude
    {
        get
        {
            return magnitude;
        }

        set
        {
            magnitude = value;
        }
    }

    /// <summary>
    /// Last angle used while wandering. SHOULD NOT SET.
    /// </summary>
    public float Angle
    {
        get
        {
            return angle;
        }

        set
        {
            angle = value;
        }
    }

    public int Skip
    {
        get
        {
            return skip;
        }

        set
        {
            skip = value;
        }
    }


    #endregion Public Properties
}
