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
public abstract class MovementBehaviour
{
    public event DeleteBehaviourHandler DeletingBehaviour;

    public float priority = 1.0f;
    public BehaviourType type = BehaviourType.Idle;

    /// <summary>
    /// Invokes the DeletingBehaviour event.
    /// </summary>
    public void OnDeleteBehaviour()
    {
        if (DeletingBehaviour != null) DeletingBehaviour(this);
    }
}