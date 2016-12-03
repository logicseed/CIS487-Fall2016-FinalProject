using UnityEngine;
using System.Collections;

public class Damage : AbilityComponent
{
    DestroyOnCollide temp;

    void Start()
    {
        temp = gameObject.GetComponent<DestroyOnCollide>();
    }

    void Update()
    {
        if (temp.activate == true)
            activate();
    }

    void activate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider x in hitColliders)
        {
            Debug.Log("You've been hit for: " + magnitude);
        }
    }
}
