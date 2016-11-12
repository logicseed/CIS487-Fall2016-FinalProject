// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class MouseTracker : MonoBehaviour
{

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () { }
    private void FixedUpdate () 
    { 
        
    }
    private void Update ()
    { 
        
    }

    private void OnGUI ()
    {
        transform.position = FindMousePosition();
    }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

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
