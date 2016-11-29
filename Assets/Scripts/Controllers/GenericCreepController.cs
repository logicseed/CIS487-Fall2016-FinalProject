using UnityEngine;
using System.Collections;
using System;

public class GenericCreepController : MonoBehaviour {
	AgentManager agent;
	ArrayList nearbyShips = new ArrayList();
	ArrayList nearbyEnemyShips = new ArrayList();
	MovementBehaviour locateBehavior,attackBehavior ;
	public GameObject goToLocation;
	float attackRange =5;
	bool isAttacking=false;
	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<AgentManager> ();
		//goToLocation = GameObject.Find ("/HomeSystem/Dank");
		this.setLocateBehavior ();
		agent.mover.AddBehaviour(locateBehavior);
		//agent.mover.AddBehaviour(this.setAttackBehavior());
	}

    // Update is called once per frame
    void Update () {
		//getNearbyShips();
		//shouldAttack();
		/*if(this.isAttacking){
			agent.mover.RemoveBehaviour (locateBehavior);
			this.setAttackTarget();
			this.setAttackBehavior();
			agent.mover.AddBehaviour (attackBehavior);
			//agent.abilityManager.autoAttack('target from target manager');
		}
		else{
			agent.mover.RemoveBehaviour (attackBehavior);
			agent.mover.AddBehaviour(locateBehavior);
		}*/
	}
	
	///<summary>
	///Sets where to go when not attacking behavior based on whether the creep is a big one or a small one
	///</summary>
	public void setLocateBehavior(){
		if (goToLocation != null) {
			agent.target.SetDirectTarget (goToLocation.GetComponent<AgentManager>());
		}

		locateBehavior = new SeekBehaviour (agent.target.direct,true);
	}

	///<summary>
	///Sets where to attack behavior based on whether the creep is a big one or a small one
	///</summary>
	public void setAttackBehavior(){
		attackBehavior = new PursueBehaviour (agent.target.direct,true);
	}

    public void getNearbyShips(){
		nearbyShips.Clear();
		var nearbyColliders = Physics.OverlapSphere(agent.gameObject.transform.position,attackRange);
		foreach(SphereCollider shipCollider in nearbyColliders){
			nearbyShips.Add(shipCollider.gameObject.GetComponent<AgentManager>());
		}
		setEnemyShips();
	}

	public void setEnemyShips(){
		AgentType shipType;
		String teamLayer;

		this.nearbyEnemyShips.Clear();

		foreach(AgentManager shipAgent in this.nearbyShips){
			//teamcolor = shipAgent.;
			teamLayer = shipAgent.teamLayer;
			shipType = shipAgent.type;
			if(shipType==AgentType.Cruiser || shipType==AgentType.Fighter || shipType==AgentType.Player){
				if(/*this.agent.teamColor!= teamcolor && */this.agent.teamLayer != teamLayer){
					nearbyEnemyShips.Add(shipAgent);
				}
			}
		}
	}

	public void setAttackTarget(){
		agent.target.SetDirectTarget((AgentManager) nearbyEnemyShips[0]);

		//ADD getting agent from nearbyEnemyships either by shortest diatance or randomly or ____?
	}
	public void shouldAttack(){
		if(nearbyEnemyShips.Count ==0){
			this.isAttacking = false;
		}
		else{
			this.isAttacking =true;
		}
	}
}
