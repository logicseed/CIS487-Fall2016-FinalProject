using UnityEngine;
using System.Collections;
using System;

public class GenericCreepController : MonoBehaviour {
	AgentManager agent;
	GameObject seekTarget;
	MovementBehaviour behavior ;
	// Use this for initialization
	void Start () {
		agent.target.SetDirectTarget(seekTarget.GetComponent<AgentManager>());
		behavior = new SeekBehaviour(agent.target.direct,true);
	agent.mover.AddBehaviour(behavior);
	}

    private void setSeekTarget()
    {
        
    }

    // Update is called once per frame
    void Update () {
	
	}
}
