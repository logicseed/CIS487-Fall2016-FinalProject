// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AgentManager))]
[DisallowMultipleComponent]
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
