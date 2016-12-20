// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class NullStandardMover : StandardMover
{
    public float maxVelocity = 0.0f;
    public float maxSteering = 0.0f;

    new public void AddBehaviour(MovementBehaviour behaviour) { }
    new public void RemoveBehaviour(MovementBehaviour behaviour) { }

    new public Vector3 velocity { get { return Vector3.zero; } }
    new public Vector3 heading { get { return Vector3.forward; } }
}
