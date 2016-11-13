// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Properties of a <see cref="GameObject"/> utilizing the <see cref="StandardMover"/> script.
/// </summary>
[System.Serializable]
public class MoverProperties
{
    #region Public Fields

    /// <summary>
    /// Current local space velocity vector of this mover.
    /// </summary>
    //[HideInInspector]
    public Vector3 currentVelocity;

    /// <summary>
    /// Current world space position of this mover.
    /// </summary>
    //[HideInInspector]
    public Vector3 currentPosition;

    /// <summary>
    /// Direction of the current velocity.
    /// </summary>
    //[HideInInspector]
    public Vector3 currentHeading;

    /// <summary>
    /// The maximum speed that this mover can attain.
    /// </summary>
    [Tooltip("The maximum speed that this mover can attain.")]
    public float maximumSpeed;

    /// <summary>
    /// The maximum steering that can modify this mover's velocity.
    /// </summary>
    [Tooltip("The maximum steering that can modify this mover's velocity.")]
    public float maximumSteering;

    /// <summary>
    /// The mass of the mover.
    /// </summary>
    [Tooltip("The mass of the mover.")]
    public float moverMass;

    #endregion Public Fields
}