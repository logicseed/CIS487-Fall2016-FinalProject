using UnityEngine;
using System.Collections;

public class DestoryAfterRange : MonoBehaviour
{
    Vector3 temp;
    public float range;

    // Use this for initialization
    void Start ()
    {
        temp = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(temp, gameObject.transform.position) >= range)
            Destroy(gameObject);
	}
}
