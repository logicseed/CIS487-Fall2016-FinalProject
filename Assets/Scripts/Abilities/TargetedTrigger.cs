using UnityEngine;
using System.Collections;

public class TargetedTrigger : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float range;

    public void cast(int effect)
    {
        //Grab target manager
        if (Vector3.Distance(gameObject.transform.position, FindMousePosition()) <= range)
        {
            if (effect == 0 || effect == 4) //Damage and debuff
            {
                //Only can cast on enemy units
            }
            else if (effect == 1 || effect == 2) //Sheilds and buffs
            {
                //Only can cast on friendly units that are not creeps
            }
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
