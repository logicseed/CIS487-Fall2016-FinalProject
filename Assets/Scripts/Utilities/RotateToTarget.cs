using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	public Transform target;
	public int range = 15;

//#region MonoBehaviour Methods
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 targetPosition = target.transform.position;
		targetPosition.y = transform.localPosition.y;
		//targetPosition.x = transform.localPosition.x;
		transform.LookAt (targetPosition);
		transform.Rotate (0,0,0);*/
		if (Vector3.Distance (target.position, transform.position) <= range) {
			float AngleRad = Mathf.Atan2 (target.position.x - transform.position.x, target.position.z - transform.position.z);
			float angle = (Mathf.Rad2Deg * AngleRad);
			transform.rotation = Quaternion.AngleAxis (angle - 90, new Vector3 (0, 1, 0));
			transform.Rotate (-90, 0, 0);
		} else {
			//if(!transform.rotation.Equals(this.transform.parent)){
				Vector3 targetDir = this.transform.parent.transform.position;
				float step = 3 * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
				transform.rotation = Quaternion.LookRotation(newDir);
			//}
		}


	}
}
//#endregion MonoBehaviour Methods
