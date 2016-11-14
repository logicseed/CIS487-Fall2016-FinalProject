// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ClickToMoveController : MonoBehaviour
{
    private StandardMover mover;
    private GameObject seekGraphic;
    private GameObject fleeGraphic;
    public StandardMover seekTestNPC;
    public StandardMover pursueTestNPC;

    private int lastBehaviour;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start ()
    {
        mover = gameObject.GetComponent<StandardMover>();
        //seekTestNPC.AddBehaviour(new SeekBehaviour(transform));
        //pursueTestNPC.AddBehaviour(new PursueBehaviour(transform));
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
            
            MovementBehaviour behaviour = new SeekBehaviour(seekGraphic.transform);

            mover.AddBehaviour(behaviour);

            // var behaviour = new MovementBehaviour();
            // behaviour.Type = MovementType.Wander;
            // behaviour.DeleteTransformNull = false;
            // behaviour.DeleteAfterFlee = false;
            // behaviour.DeleteUponArrived = false;

            //mover.AddBehaviour(behaviour);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (fleeGraphic != null)
            {
                Destroy(fleeGraphic);
            }
            fleeGraphic = Instantiate(Resources.Load("MoveTarget")) as GameObject;
            fleeGraphic.GetComponent<Renderer>().material.color = Color.red;
            fleeGraphic.transform.position = FindMousePosition();
            
            FleeBehaviour behaviour = new FleeBehaviour(fleeGraphic.transform);
            behaviour.DeleteWhenOutOfRange = true;

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
