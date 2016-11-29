using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	public GameObject target;
	public int range = 15;

//#region MonoBehaviour Methods
	// Use this for initialization
	void awake(){
	}

	void Start () {
		//defaultPosition=transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null){
			if(Vector3.Distance(target.transform.position,transform.position)<=range){
				transform.LookAt(target.transform.position);
			}
			else {
				transform.rotation=transform.parent.rotation;
			}	
		}
		
		
		


	}
}
//#endregion MonoBehaviour Methods
