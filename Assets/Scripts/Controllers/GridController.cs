// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class GridController : MonoBehaviour
{
    new private MeshRenderer renderer;
    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }
    private void FixedUpdate () { }
    private void Update () {
        if (Input.GetButtonDown("Grid Visibility"))
        {
            renderer.enabled = !renderer.enabled;
        }
    }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
