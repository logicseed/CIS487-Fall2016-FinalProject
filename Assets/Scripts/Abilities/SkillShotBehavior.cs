using UnityEngine;
using System.Collections;

public class SkillShotBehavior : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    private Vector3 direction;

    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;
    [HideInInspector]
    public float force;

    public void cast()
    {
        GameObject tempObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        Rigidbody tempRigidbody = tempObject.GetComponent<Rigidbody>();
        direction = FindMousePosition() - abilitySpawnLoc.position;
        direction.Normalize();
        tempObject.transform.LookAt(direction);
        tempRigidbody.velocity = direction * force;
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
