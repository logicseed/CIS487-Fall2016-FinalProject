// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class SpaceshipMover : MonoBehaviour
{
    public float maximumVelocity;
    public float currentVelocity;
    public float sdfds;


    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () { }
    private void FixedUpdate () { }
    private void Update () { }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

    public void MoveTo(Vector3 location)
    {
        transform.Translate(location);
    }
}
