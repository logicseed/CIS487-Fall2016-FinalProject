using UnityEngine;
using System.Collections;

public class Damage : AbilityComponent
{
    void OnTriggerEnter()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider x in hitColliders)
        {
            Debug.Log("You've been hit for: " + magnitude);
        }
    }
}
