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
    protected MovementBehaviour behaviour;
    protected AbstractBehaviourComponent parentBehaviour;

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
        this.agent = parentBehaviour.agent;
    }
}