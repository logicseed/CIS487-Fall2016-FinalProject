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
	public float startDelay = 2.0f;

	public bool spawnSquad = false;
	// Use this for initialization
	void Start () {
		if (spawnable!= null) {
			InvokeRepeating ("spawnSpawnable",startDelay,spawnRate);
		}

	}

	public void Update(){
	}

	private void spawnSpawnable(){
		if (spawnSquad) {
			GameObject instance1 = Instantiate(spawnable);
			instance1.transform.position = transform.position;
			GameObject instance2 = Instantiate(spawnable);
			Vector3 offset1 = transform.position;
			offset1.x += 5;
			instance2.transform.position = offset1;
			GameObject instance3 = Instantiate(spawnable);
			Vector3 offset2 = transform.position;
			offset2.x -= 5;
			instance3.transform.position = offset2;
		} else {
			GameObject instance = Instantiate(spawnable);
			instance.transform.position = transform.position;
		}

		//instance.
	}
}
