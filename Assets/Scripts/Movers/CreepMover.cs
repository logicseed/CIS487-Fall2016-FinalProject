using UnityEngine;
using System.Collections;

public class CreepMover : MonoBehaviour 
{

	//public MovementBehaviour movementBehaviour;
	//public GameObject target;
	//public AgentManager agentmanager;
	public Transform target;
	private GameObject moon1,moon2,moon3,moon4;
	//public GameObject basetocap;
	//public LocationTarget capbase;

	#region MonoBehavior Methods

	private void Start()
	{
		moon1 = GameObject.Find ("/Capital System/Moons/Capture Moon 1/MoonObject");
		moon2 = GameObject.Find ("/Capital System/Moons/Capture Moon 2/MoonObject");
		moon3 = GameObject.Find ("/Capital System/Moons/Capture Moon 3/MoonObject");
		moon4 = GameObject.Find ("/Capital System/Moons/Capture Moon 4/MoonObject");
		var agentmanager = this.GetComponent<AgentManager> ();
		//agentmanager.target.SetLocationTarget (this.getClosestMoon().transform.position);
		//target.position = agentmanager.target.GetPositionTarget ().location;
		target = this.getClosestMoon().transform;
		MovementBehaviour movementBehaviour = new SeekBehaviour (target,true); 
		agentmanager.mover.AddBehaviour (movementBehaviour);

	}
	private GameObject getClosestMoon(){
		//float dist;
		GameObject[] moons = { moon1, moon2, moon3, moon4 };
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
	#endregion MonoBehaviour Methods

}

