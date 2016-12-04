using UnityEngine;
using System.Collections;

public class Gravity : AbilityComponent
{
    void Update()
    {
        Pull();
    }

    void Pull()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach(Collider other in hitColliders)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, gameObject.transform.position, Time.deltaTime * magnitude);
        }
    }
}
