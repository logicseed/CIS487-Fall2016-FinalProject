using UnityEngine;
using System.Collections;

public class SkillShotBehavior : MonoBehaviour
{
    Vector3 direction;

    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;
    [HideInInspector]
    public float force;

    public void cast()
    {
        GameObject instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        Rigidbody tempRigidbody = instantiatedObject.GetComponent<Rigidbody>();
        direction = FindMousePosition() - abilitySpawnLoc.position;
        direction.Normalize();
        instantiatedObject.transform.LookAt(direction);
        tempRigidbody.AddForce(direction * force, ForceMode.VelocityChange);
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
