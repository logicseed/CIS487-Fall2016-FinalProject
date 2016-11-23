using UnityEngine;
using System.Collections;

public class Damage : Component
{
    void OnTriggerEnter(Collider col)
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach(Collider x in hitColliders)
        {
            //Damage in magnitude agent
        }
    }
}
