// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generic mover for all space-based objects that use <see cref="MovementBehaviour"/>s to move.
/// </summary>
[DisallowMultipleComponent]
public class StandardMover : MonoBehaviour
{
    #region Inspector Fields

    /// <summary>
    /// Properties of the mover.
    /// </summary>
    [Tooltip("Movement properties of the mover.")]
    public MoverProperties movementProperties;

    /// <summary>
    /// GameObject reference to the graphical representation of this mover.
    /// </summary>
    [Tooltip("GameObject reference to the graphical representation of this mover.")]
    public Transform graphicsGameObject;

    #endregion Inspector Fields

    #region MonoBehaviour Methods

    private void FixedUpdate()
    {
        UpdateMovementProperties();
        UpdateGraphicsHeading();
        UpdateMoverPosition();
        RemoveDeletedBehaviours();
    }

    #endregion MonoBehaviour Methods

    #region Private Fields

    private List<MovementBehaviour> behaviours = new List<MovementBehaviour>();
    private List<MovementBehaviour> behavioursToRemove = new List<MovementBehaviour>();

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Updates <see cref="movementProperties"/> based on recent movement and behaviours.
    /// </summary>
    private void UpdateMovementProperties()
    {
        movementProperties.currentPosition = transform.position;
        
        movementProperties.currentVelocity = CalculateNewVelocity();

        if (movementProperties.currentVelocity != Vector3.zero)
            movementProperties.currentHeading = movementProperties.currentVelocity.normalized;
    }

    /// <summary>
    /// Calculates a new velocity based on all of the mover's movement behaviours.
    /// </summary>
    /// <returns>Vector3 representing the new velocity.</returns>
    /// <remarks>
    /// Uses the Decorator pattern.
    /// </remarks>
    private Vector3 CalculateNewVelocity()
    {
        //Debug.Log("Number of behaviours: " + behaviours.Count);
        AbstractBehaviour movementBehaviour = new IdleBehaviour(movementProperties, new MovementBehaviour());

        foreach (var behaviour in behaviours)
        {
            switch (behaviour.Type)
            {
                case MovementType.Seek:
                    movementBehaviour = new SeekBehaviour(movementBehaviour, behaviour);
                    break;
                case MovementType.Flee:
                    movementBehaviour = new FleeBehaviour(movementBehaviour, behaviour);
                    break;
                case MovementType.Wander:
                    movementBehaviour = new WanderBehaviour(movementBehaviour, behaviour);
                    break;
            }
        }
        return movementBehaviour.NewVelocity();
    }

    /// <summary>
    /// Updates the <see cref="GameObject"/> that represent the graphics for this mover to face to correct heading for
    /// the mover's current velocity.
    /// </summary>
    private void UpdateGraphicsHeading()
    {
        if (graphicsGameObject != null)
        {
            var heading = transform.position + movementProperties.currentHeading;
            graphicsGameObject.LookAt(heading);
        }
    }

    /// <summary>
    /// Updates the position of the mover based on the most recent changes to its movement properties.
    /// </summary>
    private void UpdateMoverPosition()
    {
        transform.Translate(movementProperties.currentVelocity * Time.fixedDeltaTime);
        // transform.position = Vector3.Slerp(
        //     transform.position,
        //     transform.position + CurrentVelocity,
        //     Time.fixedDeltaTime
        // );
    }

    /// <summary>
    /// Removes all behaviours marked for removal from this mover.
    /// </summary>
    private void RemoveDeletedBehaviours()
    {
        if (behavioursToRemove.Count > 0)
        {
            foreach (var behaviour in behavioursToRemove)
            {
                behaviour.DeletingBehaviour -= new DeleteBehaviourHandler(RemoveBehaviour);
                behaviours.Remove(behaviour);
            }
            behavioursToRemove.Clear();
            behaviours.TrimExcess();
        }
    }

    #endregion Private Methods

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="behaviour"></param>
    public void AddBehaviour(MovementBehaviour behaviour)
    {
        behaviour.DeletingBehaviour += new DeleteBehaviourHandler(RemoveBehaviour);
        behaviours.Add(behaviour);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="behaviour"></param>
    public void RemoveBehaviour(MovementBehaviour behaviour)
    {
        behavioursToRemove.Add(behaviour);
    }

    /// <summary>
    /// 
    /// </summary>
    public Vector3 CurrentVelocity
    {
        get
        {
            return movementProperties.currentVelocity;
        }
    }

    #endregion Public Methods
}
