using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float range;

    [HideInInspector]
    public Vector3 velocity;

    public void cast()
    {
        GameObject tempObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        Rigidbody tempRigidbody = tempObject.GetComponent<Rigidbody>();
    }
}
