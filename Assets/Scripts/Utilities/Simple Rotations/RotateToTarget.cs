using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	public GameObject target;
	public int range = 15;
	private Transform defaultPosition;
//#region MonoBehaviour Methods
	// Use this for initialization
	void awake(){
		defaultPosition=transform;
	}

	void Start () {
		//defaultPosition=transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null){
			foreach(Transform child in transform){
			if(Vector3.Distance(target.transform.position,transform.position)<=range){
				transform.LookAt(target.transform.position);
			}
			else {
				transform.rotation=transform.parent.rotation;
			}	
		}
		}
		
		
		


	}
}
//#endregion MonoBehaviour Methods
