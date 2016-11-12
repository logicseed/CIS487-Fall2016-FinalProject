// Marc King - mjking@umich.edu

using UnityEngine;

public class DefaultBehaviour : MonoBehaviour
{
    public MovementType movementType = MovementType.Idle;
    public Transform targetTransform = null;
    public Vector3 position = Vector3.zero;
    public float strength = 1.0f;
    public bool deleteUponArrived = false;
    public bool deleteAfterFlee = false;
    public bool deleteTransformNull = false;
    public float arrivalRadius = 3.0f;
    public float arrivedRadius = 0.5f;
    public float fleeRadius = 20.0f;
    public float orbitRadius = 10.0f;
    public float wanderRate = 1.0f;
    public float wanderMagnitude = 2.0f;
    public float wanderAngleChange = 30.0f;
    public float wanderTime = -1.0f;
    public float pursuePrediction = 10.0f;

    #region MonoBehavior Methods

    private void Start()
    {
        var mover = gameObject.GetComponent<StandardMover>();

        var behaviour = new MovementBehaviour();
        behaviour.Type = movementType = MovementType.Idle;
        behaviour.Transform = targetTransform;
        behaviour.Position = position;
        behaviour.Strength = strength;
        behaviour.DeleteUponArrived = deleteUponArrived;
        behaviour.DeleteAfterFlee = deleteAfterFlee;
        behaviour.DeleteTransformNull = deleteTransformNull;
        behaviour.ArrivalRadius = arrivalRadius;
        behaviour.ArrivedRadius = arrivedRadius;
        behaviour.FleeRadius = fleeRadius;
        behaviour.OrbitRadius = orbitRadius;
        behaviour.WanderRate = wanderRate;
        behaviour.WanderMagnitude = wanderMagnitude;
        behaviour.WanderAngleChange = wanderAngleChange;
        behaviour.WanderTime = wanderTime;
        behaviour.PursuePrediction = pursuePrediction;

        mover.AddBehaviour(behaviour);
    }

    #endregion MonoBehaviour Methods

}
