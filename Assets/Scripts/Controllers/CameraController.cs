// Marc King - mjking@umich.edu

using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Inspector Fields

    [Header("Isometric Camera Transforms")]

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Transform targetTransform;

    [Header("Zoom Settings")]

    [SerializeField]
    private bool allowManualZoom;

    [SerializeField]
    private float scrollSpeed;

    [SerializeField]
    [Range(5, 500)]
    private float maximumZoomLevel;

    [SerializeField]
    [Range(5, 500)]
    private float minimumZoomLevel;

    [SerializeField]
    [Range(0.1f, 10.0f)]
    private float zoomSpeed;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float lookAboveDistance;

    [Header("Rotation Settings")]

    [SerializeField]
    [Range(10,500)]
    private float rotationSpeed;

    #endregion Inspector Fields

    #region Data Fields

    private float defaultZoomLevel;
    private float newZoomLevel;

    #endregion Data Fields

    #region MonoBehaviour Methods

    private void Awake ()
    {
        // Make sure we have an instance of the camera
        if (cameraTransform == null)
        {
            cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        // Make sure we have an instance of the target
        if (targetTransform == null)
        {
            targetTransform = cameraTransform.parent;
        }

        // Fix invalid inspector settings
        if (maximumZoomLevel < minimumZoomLevel)
        {
            maximumZoomLevel = minimumZoomLevel;
        }
    }


    private void Start ()
    {
        defaultZoomLevel = ZoomLevel;
        newZoomLevel = ZoomLevel;
    }

    private void Update()
    {
        CheckZoomRange();
        UpdateZoom();
        UpdateTarget();
        UpdateRotation();
    }

    #endregion MonoBehaviour Methods

    #region Zoom Methods

    public float ZoomLevel
    {
        get { return cameraTransform.position.y; }
        set { newZoomLevel = value; }
    }

    public float DefaultZoomLevel
    {
        get { return defaultZoomLevel; }
        set { defaultZoomLevel = value; }
    }

    public void RestoreZoom()
    {
        ZoomLevel = DefaultZoomLevel;
    }

    /// <summary>
    /// Ensures that the requested zoom level doesn't fall outside of the allowed range.
    /// </summary>
    private void CheckZoomRange()
    {
        if (newZoomLevel > maximumZoomLevel || ZoomLevel > maximumZoomLevel) newZoomLevel = maximumZoomLevel;
        if (newZoomLevel < minimumZoomLevel || ZoomLevel < minimumZoomLevel) newZoomLevel = minimumZoomLevel;
    }

    /// <summary>
    /// Performs a frame-based update to the current zoom level based on the zoom speed.
    /// </summary>
    private void UpdateZoom()
    {
        Vector3 cameraMovement = Vector3.zero;

        if (allowManualZoom)
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            newZoomLevel -= scroll;
        }

        if (ZoomLevel > newZoomLevel) cameraMovement = new Vector3(0.0f, -1.0f, 1.0f) * zoomSpeed; // zoom in
        if (ZoomLevel < newZoomLevel) cameraMovement = new Vector3(0.0f, 1.0f, -1.0f) * zoomSpeed; // zoom out

        cameraTransform.Translate(cameraMovement, targetTransform);
    }

    private void UpdateTarget()
    {
        var lookAtPosition = targetTransform.position + new Vector3(0.0f, lookAboveDistance, 0.0f);
        cameraTransform.LookAt(lookAtPosition);
    }

    #endregion Zoom Methods

    #region Rotation Methods

    /// <summary>
    /// Performs a frame-based update to the camera rotation when receiving input.
    /// </summary>
    private void UpdateRotation()
    {
        var rotation = Input.GetAxis("Rotate Camera") * rotationSpeed * Time.deltaTime;
        targetTransform.Rotate(0.0f, rotation, 0.0f);
    }

    #endregion Rotation Methods
}
