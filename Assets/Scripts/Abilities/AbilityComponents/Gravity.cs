using UnityEngine;
using System.Collections;

public class Gravity : AbilityComponent
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Pull", 0.0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pull()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach(Collider other in hitColliders)
        {
            other.GetComponent<Rigidbody>().AddForce(((gameObject.transform.position
            - other.transform.position).normalized) * magnitude, ForceMode.Acceleration);
        }
    }
}
