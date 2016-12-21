using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterController : MonoBehaviour {
	AgentManager agent;
	public List<AgentManager> nearbyEnemyShips;
	MovementBehaviour attackBehavior ;
	public bool attacking = false, targeting = false;
	public GameObject attackTarget;

	int targetingRange = 30;
	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<AgentManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		getNearbyEnemyShips ();
		if (targeting) {
			targetEnemyShip ();
			targeting = false;
		}
		if (attackTarget != null&& !targeting) {
			attacking = true;
			attackBehavior = new SeekBehaviour(attackTarget.GetComponent<AgentManager>());
			attackBehavior.priority = 10;
			agent.mover.AddBehaviour (attackBehavior);
			agent.target.SetDirectTarget (attackTarget);
		}

		if (attackTarget == null) {
			if (attackBehavior != null) {
				agent.mover.RemoveBehaviour (attackBehavior);
			}

			attacking = false;
		}
	}

	public void getNearbyEnemyShips(){
		nearbyEnemyShips.Clear ();
		Collider[] nearbyColliders = Physics.OverlapSphere (transform.position,targetingRange);
		foreach(var item in nearbyColliders){
			var shipAgent = item.gameObject.GetComponent<AgentManager> ();
			if(shipAgent.team != agent.team && (shipAgent.type == AgentType.Cruiser || shipAgent.type == AgentType.Fighter || shipAgent.type == AgentType.Player)){
				nearbyEnemyShips.Add (item.gameObject.GetComponent<AgentManager>());
			}
		}
		if (nearbyEnemyShips.Count != 0 &&!attacking)
			targeting = true;
	}

	public void targetEnemyShip(){
		int target = Random.Range (0, nearbyEnemyShips.Count);
		attackTarget = nearbyEnemyShips[target].gameObject;
	}
}
