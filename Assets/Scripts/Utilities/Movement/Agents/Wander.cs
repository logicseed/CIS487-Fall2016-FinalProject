﻿// Marc King - mjking@umich.edu

using UnityEngine;

public class Wander : Face
{
    public float offset;
    public float radius;
    public float rate;

    #region MonoBehavior Methods

    protected override void Awake () 
    { 
        target = new GameObject();
        target.transform.position = transform.position;
        base.Awake();
    }

    private void Start () { }
    private void FixedUpdate () { }
    private void Update () { }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float wanderOrientation = Random.Range(-1.0f, 1.0f) * rate;
        float targetOrientation = wanderOrientation + agent.orientation;
        Vector3 orientationVec = GetOriAsVec(agent.orientation);
        Vector3 targetPosition = (offset * orientationVec) + transform.position;
        targetPosition = targetPosition + (GetOriAsVec(targetOrientation) * radius);
        targetAux.transform.position = targetPosition;
        steering = base.GetSteering();
        steering.linear = targetAux.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear *= agent.maxAccel;
        return steering;
    }
}
