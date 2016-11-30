// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AgentManager))]
[DisallowMultipleComponent]
public class WanderMover : MonoBehaviour
{
    private AgentManager agent;
    public WanderBehaviour movementBehaviour;

    #region MonoBehavior Methods

    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        agent.mover.AddBehaviour(movementBehaviour);
    }
    #endregion MonoBehaviour Methods

    public void StopWander()
    {
        agent.mover.RemoveBehaviour(movementBehaviour);
    }
}
