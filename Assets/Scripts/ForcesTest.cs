// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class ForcesTest : MonoBehaviour
{

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(10.0f, 0.0f, 50.0f), ForceMode.VelocityChange);
    }
    private void FixedUpdate () { }
    private void Update () { }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
