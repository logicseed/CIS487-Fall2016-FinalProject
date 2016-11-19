//Harrison Telfer htelfer@umich.edu

using UnityEngine;
using System.Collections;
/**
 * attached to a child of a spawning object called spawnpoint
 * 
 * 
**/
public class SpawnController : MonoBehaviour {

	//object you want to have spawn from the is object
	public GameObject spawnable;
	//spawn spawnable object every x seconds
	public float spawnRate =5.0f;
	//begin spawning after x seconds of being created
	public float startDelay = 1.0f;
	// Use this for initialization
	void Start () {
		if (spawnable!= null) {
			InvokeRepeating ("spawnSpawnable",startDelay,spawnRate);
		}

	}

	private void spawnSpawnable(){
		GameObject instance = Instantiate(spawnable);
	}
}
