// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class BackgroundCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    [Range(10, 500)]
    private float rotationSpeed;
    #region MonoBehavior Methods
    private void Awake()
    { // Make sure we have an instance of the camera
        if (cameraTransform == null)
        {
            cameraTransform = GameObject.FindGameObjectWithTag("BackgroundCamera").transform;
        }
    }
    private void Start() { }
    private void FixedUpdate() { }
    private void Update() { 
        
        UpdateRotation(); }
    private void LateUpdate() { }
    private void OnDestroy() { }
    #endregion MonoBehaviour Methods

    private void OnGizmo()
    {
        Debug.DrawRay(
            Vector3.zero, new Vector3(0.0f,0.0f,1000.0f),
            Color.magenta
        );
    }
    /// <summary>
    /// /// Performs a frame-based update to the camera rotation when receiving input.
    /// </summary>
    private void UpdateRotation()
    {
        var rotation = Input.GetAxis("Rotate Camera") * rotationSpeed * Time.deltaTime;
        //cameraTransform.Rotate(0.0f, rotation, 0.0f);
        var tet = Quaternion.Euler(0.0f, -rotation, 0.0f);
        transform.rotation *= tet;

        // transform.rotation = Quaternion.Slerp(
        //     transform.rotation, 
        //     transform.rotation * Quaternion.Euler(0.0f, rotation, 0.0f),
        //     Time.deltaTime
        // );
    }
}
