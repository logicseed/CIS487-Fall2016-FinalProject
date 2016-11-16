using UnityEngine;
using System.Collections;

public class AreaOfEffect : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float range;

    [HideInInspector]
    public float aoeRadius; //Size of aoe
    [HideInInspector]
    public Transform aoeLocation; //Location for aoe

    public void cast()
    {
        GameObject tempObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        Rigidbody tempRigidbody = tempObject.GetComponent<Rigidbody>();
    }
}
