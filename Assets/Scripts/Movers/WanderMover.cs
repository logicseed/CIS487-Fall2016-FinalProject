﻿// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
[RequireComponent(typeof(StandardMover))]
public class WanderMover : MonoBehaviour
{

    public WanderBehaviour movementBehaviour;

    #region MonoBehavior Methods

    private void Start()
    {
        var mover = gameObject.GetComponent<StandardMover>();
        mover.AddBehaviour(movementBehaviour);
    }
    #endregion MonoBehaviour Methods

}