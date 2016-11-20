using UnityEngine;
using System.Collections;

public class CreepController : MonoBehaviour {
	AgentManager agent;
	GameObject[] moons= new GameObject[4];
	float attackRange=5;
	MovementBehaviour currentBehavior;
	// Use this for initialization
	void Start () {
		moons[0]=GameObject.Find ("/Capital System/Moons/Capture Moon 1/MoonObject");
		moons[1]=GameObject.Find ("/Capital System/Moons/Capture Moon 2/MoonObject");
		moons[2]=GameObject.Find ("/Capital System/Moons/Capture Moon 3/MoonObject");
		moons[3]=GameObject.Find ("/Capital System/Moons/Capture Moon 4/MoonObject");
		agent = gameObject.GetComponent<AgentManager> ();
		seekCapturePoint ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private GameObject checkNearbyShips(){
		return new GameObject();
	}

	private GameObject getClosestMoon(){
		GameObject nearMoon;
		float temp = Vector3.Distance (moons [0].transform.position, transform.position);
		nearMoon = moons [0];
		for (int i = 0; i < moons.Length; i++) {
			if(Vector3.Distance (moons [i].transform.position, transform.position)<temp){
				temp = Vector3.Distance (moons [i].transform.position, transform.position);
				nearMoon = moons [i];
			}
		}
		return nearMoon;
	}

	private void seekCapturePoint(){
		this.setTargetCapture ();
		currentBehavior = new SeekBehaviour (agent.target.GetDirectTarget().gameObject.transform,true);
		agent.mover.AddBehaviour (currentBehavior);
	}

	private void setTargetCapture(){
		//var target = new DirectTarget (TargetType.EnemyCapture,getClosestMoon());
		agent.target.SetDirectTarget (TargetType.EnemyCapture,getClosestMoon());
	}
}
