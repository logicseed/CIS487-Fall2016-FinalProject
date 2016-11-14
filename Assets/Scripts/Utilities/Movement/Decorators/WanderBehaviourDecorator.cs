// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Causes the attached mover to wander.
/// </summary>
/// <remarks>
/// ConcreteDecorator of the Decorator pattern.
/// </remarks>
public class WanderBehaviourDecorator : ActiveBehaviourDecorator
{
    new WanderBehaviour behaviour;

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
    public WanderBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour) 
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as WanderBehaviour; }

    #endregion Constructor

    #region Public Methods

    /// <summary>
    /// Calculates the steering vector summation of all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 steering vector summation of all movement behaviours</returns>
    public override Vector3 Steering()
    {
        if (Deleting()) return parentBehaviour.Steering();


            //if (moverProperties.CurrentVelocity == Vector3.zero)
            //    moverProperties.CurrentVelocity = moverProperties.CurrentHeading * moverProperties.MaximumSteering;
            Debug.DrawRay(moverProperties.CurrentPosition, moverProperties.CurrentVelocity, Color.green);

            var center = Vector3.ClampMagnitude(
                moverProperties.CurrentHeading.normalized * moverProperties.MaximumSpeed,
                moverProperties.MaximumSpeed * behaviour.Rate
            );

            if (center == Vector3.zero) center = Vector3.forward * moverProperties.MaximumSteering;

            Debug.DrawRay(moverProperties.CurrentPosition, center, Color.red);

            var steering = Vector3.forward * behaviour.Magnitude;

            var rotation = Quaternion.AngleAxis(behaviour.Angle, Vector3.up);
            steering = (center + (rotation * steering)) - moverProperties.CurrentVelocity;

            //var newWanderAngle = (Random.value * behaviour.AngleChange) - (behaviour.AngleChange * 0.5f);
            var newWanderAngle = Random.value * behaviour.AngleChange - behaviour.AngleChange * 0.5f;

            behaviour.Angle += newWanderAngle;

            //steering = steering / 100;
            Debug.DrawRay(moverProperties.CurrentPosition, steering, Color.blue);

            return steering + parentBehaviour.Steering();

    }

    #endregion Public Methods

    private bool Deleting()
    {
        if (behaviour.Time != -1.0f)
        {
            if (behaviour.Time > 0.0f) behaviour.Time -= Time.fixedDeltaTime;
            if (behaviour.Time < 0.0f && behaviour.Time >= -1.0f)
            {
                behaviour.OnDeleteBehaviour();
                return true;
            }
        }
        return false;
    }
}
