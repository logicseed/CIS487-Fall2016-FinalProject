// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class ClickToMoveController : MonoBehaviour
{
    private SpaceshipMover mover;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start ()
    {
        mover = gameObject.GetComponent<SpaceshipMover>();
    }
    private void FixedUpdate () { }
    private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var location = FindMousePosition();
            mover.MoveTo(location);
        }

    }

    private Vector3 FindMousePosition()
    {
        var plane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            var location = ray.GetPoint(distance);
            return location;
        }
        return Vector3.zero;
    }

    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
