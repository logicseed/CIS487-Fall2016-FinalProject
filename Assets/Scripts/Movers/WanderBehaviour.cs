// Marc King - mjking@umich.edu

using UnityEngine;

public class WanderBehaviour : ActiveBehaviour
{
    #region Constructor

    /// <summary>
    /// Constructor for wander behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    public WanderBehaviour(AbstractBehaviour parentBehaviour, MovementBehaviour behaviour) 
    : base(parentBehaviour, behaviour) { }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering()
    {
        if (Deleting()) return parentBehaviour.Steering();

        if (moverProperties.currentVelocity == Vector3.zero)
            moverProperties.currentVelocity = moverProperties.currentHeading * moverProperties.maximumSteering;
        
        var center = Vector3.ClampMagnitude(
            moverProperties.currentHeading.normalized * moverProperties.maximumSpeed,
            moverProperties.currentVelocity.magnitude
        );

        if (center == Vector3.zero) center = Vector3.forward * 0.001f;

        var steering = Vector3.forward * behaviour.WanderMagnitude;

        var rotation = Quaternion.AngleAxis(behaviour.WanderAngle, Vector3.up);
        steering = (center + (rotation * steering)) - moverProperties.currentVelocity;

        var newWanderAngle = (Random.value * behaviour.WanderAngleChange) - (behaviour.WanderAngleChange * 0.5f);
        
        behaviour.WanderAngle += newWanderAngle;

        return steering + parentBehaviour.Steering();
    }

    #endregion Public Methods
}
