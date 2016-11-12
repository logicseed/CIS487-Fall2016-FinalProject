// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class ClickToMoveController : MonoBehaviour
{
    private StandardMover mover;
    private GameObject seekGraphic;
    private GameObject fleeGraphic;

    private int lastBehaviour;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start ()
    {
        mover = gameObject.GetComponent<StandardMover>();
    }
    private void FixedUpdate () { }
    private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (seekGraphic != null)
            {
                Destroy(seekGraphic);
            }
            seekGraphic = Instantiate(Resources.Load("MoveTarget")) as GameObject;
            seekGraphic.transform.position = FindMousePosition();
            
            // var behaviour = new MovementBehaviour();
            // behaviour.Type = MovementType.Seek;
            // behaviour.Transform = seekGraphic.transform;

            // mover.AddBehaviour(behaviour);

            var behaviour = new MovementBehaviour();
            behaviour.Type = MovementType.Wander;
            behaviour.DeleteTransformNull = false;
            behaviour.DeleteAfterFlee = false;
            behaviour.DeleteUponArrived = false;

            mover.AddBehaviour(behaviour);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (seekGraphic != null)
            {
                Destroy(fleeGraphic);
            }
            fleeGraphic = Instantiate(Resources.Load("MoveTarget")) as GameObject;
            fleeGraphic.transform.position = FindMousePosition();
            
            var behaviour = new MovementBehaviour();
            behaviour.Type = MovementType.Flee;
            behaviour.Transform = fleeGraphic.transform;

            mover.AddBehaviour(behaviour);
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
