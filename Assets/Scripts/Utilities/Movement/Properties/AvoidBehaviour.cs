﻿// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class AvoidBehaviour : MovementBehaviour
{
    public float maxDistance = 2.0f;
    public float sphereRadius = 5.0f;
    public float personalSpace = 5.0f;

    public AvoidBehaviour(float priority = 50.0f)
    {
        this.priority = priority;
    }
}
