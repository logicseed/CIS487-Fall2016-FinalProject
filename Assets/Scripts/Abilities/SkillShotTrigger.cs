using UnityEngine;
using System.Collections;

public class SkillShotTrigger : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    private Vector3 velocity;

    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float range;
    [HideInInspector]
    public float force;
        
    public void cast(int effect)
    {
        if (effect == 4)
        {
            //Do movement stuff
        }
        else
        {
            GameObject tempObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
            Rigidbody tempRigidbody = tempObject.GetComponent<Rigidbody>();
            velocity = FindMousePosition();
            tempObject.transform.LookAt(velocity);
            tempRigidbody.velocity = (velocity - abilitySpawnLoc.position) * force;
        }
    }

    private Vector3 FindMousePosition()
    {
        var plane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 0.0f;

        if (plane.Raycast(ray, out distance))
        {
            var location = ray.GetPoint(distance);
            return location;
        }
        return Vector3.zero;
    }
}
