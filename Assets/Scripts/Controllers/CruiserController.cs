using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CruiserController : MonoBehaviour {
	AgentManager agent;
	public List<GameObject> capturePlanets;
	public bool attacking = false,retarget=false;

	public float attackRange=30.0f;
	public GameObject captureTarget;
	MovementBehaviour currentSeek;
	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<AgentManager> ();
		capturePlanets.Add(GameObject.Find ("/Capture 1/Planet 2"));
		capturePlanets.Add(GameObject.Find ("/Capture 2/Hoth"));
		capturePlanets.Add(GameObject.Find ("/Capture 3/Commerce"));
		capturePlanets.Add(GameObject.Find ("/Capture 4/Dam Ba Da"));

		captureTarget = getClosestEnemyCapturePoint ();
		if (captureTarget != null)
		{
		currentSeek = new SeekBehaviour(captureTarget.GetComponent<AgentManager>());
		agent.mover.AddBehaviour(currentSeek);
		agent.target.SetDirectTarget(captureTarget);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// if(Vector3.Distance(transform.position,captureTarget.transform.position)<attackRange && !attacking){
		// 	attacking = true;
		// 	agent.target.SetDirectTarget (captureTarget);
		// }

		

		// if(captureTarget.GetComponent<AgentManager>().team == agent.team){
		// 	attacking = false;
		// 	retarget = true;
		// }

		if (captureTarget == null || captureTarget.GetComponent<AgentManager>().team == agent.team)
		{
			agent.target.RemoveDirectTarget();
			agent.mover.RemoveBehaviour (currentSeek);
			captureTarget = null;
		}

		if (captureTarget == null)
		{
		//if (retarget) {
			
			captureTarget = getClosestEnemyCapturePoint();
			//agent.mover.RemoveBehaviour (currentSeek);
			if (captureTarget != null)
			{
			currentSeek = new SeekBehaviour(captureTarget.GetComponent<AgentManager>());
			agent.mover.AddBehaviour(currentSeek);
			agent.target.SetDirectTarget(captureTarget);
			}
			//retarget = false;
		}



		agent.target.SetDirectTarget (captureTarget);
	
	}

	private GameObject getClosestEnemyCapturePoint(){
		GameObject nearCap = null;
		// float temp = Vector3.Distance (capturePlanets [0].transform.position, transform.position);
		// nearCap = capturePlanets [0];
		// for (int i = 0; i < capturePlanets.Count; i++) {
		// 	TeamType team = capturePlanets [i].GetComponent<AgentManager> ().team;
		// 	if((Vector3.Distance (capturePlanets [i].transform.position, transform.position)<temp)&&(team!=agent.team )){
		// 		temp = Vector3.Distance (capturePlanets [i].transform.position, transform.position);
		// 		nearCap = capturePlanets [i];
		// 	}
		// }
		foreach(var capturePlanet in capturePlanets)
		{
			if (nearCap == null && capturePlanet.GetComponent<AgentManager>().team != agent.team)
			{
				nearCap = capturePlanet;
			}
			else if (capturePlanet.GetComponent<AgentManager>().team != agent.team)
			{
				if (Vector3.Distance(transform.position, capturePlanet.transform.position) < (Vector3.Distance(transform.position, nearCap.transform.position)))
				{
					nearCap = capturePlanet;
				}
			}
		}

		return nearCap;
	}
		
}
