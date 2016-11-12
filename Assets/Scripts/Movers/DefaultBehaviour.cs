// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Adds a default behaviour to a StandardMover.
/// </summary>
[RequireComponent(typeof(StandardMover))]
public class DefaultBehaviour : MonoBehaviour
{
    public MovementBehaviour movementBehaviour;

    #region MonoBehavior Methods

    private void Start()
    {
        var mover = gameObject.GetComponent<StandardMover>();
        mover.AddBehaviour(movementBehaviour);
    }
    #endregion MonoBehaviour Methods
}
