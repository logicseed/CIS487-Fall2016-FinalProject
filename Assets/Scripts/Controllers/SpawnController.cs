//Harrison Telfer htelfer@umich.edu

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
/**
 * attached to a child of a spawning object called spawnpoint
 * 
 * 
**/
public class SpawnController : NetworkBehaviour {

	//spawn spawnable object every x seconds
	public float spawnRate =30.0f;
	//begin spawning after x seconds of being created
	public float startDelay = 2.0f;

	public int spawnLimit;
	private AgentManager agent;
	public List<GameObject> capturePlanets;
	public GameObject captureTarget;

	public List<GameObject> spawnedCruisers;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<AgentManager> ();
		//capturePlanets = GameManager.instance.capturePlanets;
		capturePlanets.Add(GameObject.Find ("/Capture 1/Planet 2"));
		capturePlanets.Add(GameObject.Find ("/Capture 2/Hoth"));
		capturePlanets.Add(GameObject.Find ("/Capture 3/Commerce"));
		capturePlanets.Add(GameObject.Find ("/Capture 4/Dam Ba Da"));
		//capturePlanets[1]=GameObject.Find ("/Capture 2/Hoth");
		//capturePlanets[2]=GameObject.Find ("/Capture 3/Commerce");
		//capturePlanets[3]=GameObject.Find ("/Capture 4/Dam Ba Da");
		//Debug.Log(capturePlanets);
		captureTarget=getClosestMoon ();
		if (isServer) {
			InvokeRepeating ("spawnSpawnable",startDelay,spawnRate);
		}

	}

	public void Update(){
		captureTarget=getClosestMoon ();
	}

	[Server]
	private void spawnSpawnable(){
		foreach (var item in spawnedCruisers) {
			if (item == null) {
				spawnedCruisers.Remove (item);
			}
		}

		if (spawnedCruisers.Count < spawnLimit) {
			var cruiser = Instantiate(GameManager.Instance.characters[(int)agent.team].cruiserPrefab, transform.FindChild("Cruiser Spawn").transform.position, Quaternion.identity) as GameObject;
			var cruiserAgent =  cruiser.GetComponent<AgentManager>();

			cruiserAgent.team = agent.team;
			cruiserAgent.Start();
			cruiserAgent.target.location = captureTarget.GetComponent<AgentManager> ();

			NetworkServer.Spawn(cruiser);

			spawnedCruisers.Add(cruiser);

		}
			
	}

	private GameObject getClosestMoon(){
		GameObject nearCap;
		float temp = Vector3.Distance (capturePlanets [0].transform.position, transform.position);
		nearCap = capturePlanets [0];
		for (int i = 0; i < capturePlanets.Count; i++) {
			if(Vector3.Distance (capturePlanets [i].transform.position, transform.position)<temp){
				temp = Vector3.Distance (capturePlanets [i].transform.position, transform.position);
				nearCap = capturePlanets [i];
			}
		}

		return nearCap;
	}
}
