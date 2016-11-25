using UnityEngine;
using System.Collections;

public class NonTargetedBehavior : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;
    
    public void cast()
    {
        GameObject instantiatedObject;

        if (maxRange == 0)
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        else if(Vector3.Distance(gameObject.transform.position, FindMousePosition()) <= maxRange)
        {
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
            instantiatedObject.transform.position = FindMousePosition();
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
