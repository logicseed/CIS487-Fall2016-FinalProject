// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Represents an active (i.e. non-idle) movement behaviour.
/// </summary>
/// <remarks>
/// Abstract Decorator of the Decorator pattern.
/// </remarks>
public abstract class ActiveBehaviourDecorator : AbstractBehaviourComponent
{
    #region Protected Fields

    protected AgentProperties moverProperties;
    protected MovementBehaviour behaviour;
    protected AbstractBehaviourComponent parentBehaviour;

    #endregion Protected Fields

    #region Constructor

    /// <summary>
    /// Constructor for active behaviour.
    /// </summary>
    /// <param name="behaviour">
    /// Details for this behaviour.
    /// </param>
    /// <param name="parentBehaviour">
    /// Reference to component to decorate.
    /// </param>
    protected ActiveBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    {
        this.behaviour = behaviour;
        this.parentBehaviour = parentBehaviour;
        this.moverProperties = parentBehaviour.Properties();
    }

    #endregion Protected Fields

    #region Public Methods

    /// <summary>
    /// Gets the properties of the mover to which this behaviour is attached.
    /// </summary>
    /// <returns>MovementProperties of the mover.</returns>
    public override AgentProperties Properties()
    {
        return moverProperties;
    }

    /// <summary>
    /// Calculates a new velocity based on all attached movement behaviours.
    /// </summary>
    /// <returns>Vector3 velocity based on movement behaviour.</returns>
    public override Vector3 NewVelocity()
    {
        var steering = Steering().Truncate(moverProperties.MaximumSteering);// / moverProperties.moverMass;
        var velocity = moverProperties.CurrentVelocity + steering;
        return velocity.Truncate(moverProperties.MaximumSpeed);
    }

    #endregion Public Methods

    #region Protected Methods

    /// <summary>
    /// Determines if the behaviour should be deleted, and raises an event to do so if it does.
    /// </summary>
    /// <returns>True if the behaviour will be deleted; false otherwise.</returns>
    //protected bool Deleting()
    //{
    //    var delete = false;

        

    //    // if (behaviour.DeleteUponArrived || behaviour.DeleteAfterFlee)
    //    // {
    //    //     var distance = (behaviour.Position - moverProperties.currentPosition).magnitude;

    //    //     if (behaviour.DeleteUponArrived && distance < behaviour.ArrivedRadius) delete = true;
    //    //     if (behaviour.DeleteAfterFlee && distance > behaviour.FleeRadius) delete = true;
    //    // }

    //    // if (behaviour.WanderTime != -1.0f)
    //    // {
    //    //     if (behaviour.WanderTime > 0.0f) behaviour.WanderTime -= Time.fixedDeltaTime;
    //    //     if (behaviour.WanderTime < 0.0f && behaviour.WanderTime >= -1.0f) delete = true;
    //    // }

    //    // if (delete) behaviour.OnDeleteBehaviour();

    //    return delete;
    //}

    #endregion Protected Methods
}