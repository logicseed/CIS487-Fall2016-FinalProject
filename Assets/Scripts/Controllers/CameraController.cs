// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Allows control of the local camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("GameObjects")]
    [Tooltip("The child Camera of this controller.")]
    public GameObject cameraGO;
    [Tooltip("The child pivot of this controller.")]
    public GameObject pivotGO;
    [Tooltip("The object to follow while not in free explore.")]
    public GameObject targetGO;

    [Header("Allow Change")]
    [Tooltip("Allows the controller to change the altitude of the camera.")]
    public bool allowAltitudeChange = true;
    [Tooltip("Allows the controller to change the zoom level of the camera.")]
    public bool allowZoomChange = true;
    [Tooltip("Allows the controller to change the rotation of the camera.")]
    public bool allowRotationChange = true;
    [Tooltip("Allows the controller to change the position of the camera.")]
    public bool allowPositionChange = true;

    [Header("Rates of Change")]
    [Tooltip("How quickly the altitude will change.")]
    [Range(0.0f, 100.0f)]
    public float altitudeRate = 10;
    [Tooltip("How quickly the zoom will change.")]
    [Range(0.0f, 100.0f)]
    public float zoomRate = 10;
    [Tooltip("How quickly the rotation will change.")]
    [Range(0.0f, 100.0f)]
    public float rotationRate = 10;
    [Tooltip("How quickly the position will change.")]
    [Range(0.0f, 100.0f)]
    public float moveRate = 10;

    [Header("Extents of Change")]
    [Tooltip("Minimum degress the camera can pivot.")]
    [Range(-90.0f, 90.0f)]
    public float minimumAltitude = -90.0f;
    [Tooltip("Maximum degrees the camera can pivot.")]
    [Range(-90.0f, 90.0f)]
    public float maximumAltitude = 90.0f;
    [Space(10)]
    [Tooltip("Minimum amount of zoom.")]
    [Range(0.0f, 100.0f)]
    public float minimumZoom = 5.0f;
    [Tooltip("Maximum amount of zoom.")]
    [Range(10.0f, 1000.0f)]
    public float maximumZoom = 100.0f;

    [Header("Default Settings")]
    [Tooltip("Default degrees of camera pivot.")]
    [Range(0.0f, 100.0f)]
    public float defaultAltitude = 20.0f;
    [Tooltip("Default level of zoom.")]
    [Range(0.0f, 1000.0f)]
    public float defaultZoom = 20.0f;
    [Tooltip("Default rotation.")]
    [Range(-180.0f, 180.0f)]
    public float defaultRotation = 0.0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    private void Start()
    {
        SetToDefaultValues();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        // We can't follow a non-existent target
        if (targetGO == null) allowPositionChange = true;

        // Handle camera adjustment input

        if (allowAltitudeChange)
        {
            altitude += altitudeRate * Input.GetAxis("UpDown Camera");
        }

        if (allowZoomChange)
        {
            zoom += zoomRate * Input.GetAxis("Zoom Camera");
        }

        if (allowRotationChange)
        {
            rotation += rotationRate * Input.GetAxis("Rotate Camera");
        }

        if (allowPositionChange)
        {
            transform.Translate(
                moveRate * Input.GetAxis("LeftRight Camera"),
                0.0f, // No movement along Y axis
                moveRate * Input.GetAxis("ForwardBack Camera")
                );
        }
        else
        {
            transform.position = targetGO.transform.position;
        }

        if (Input.GetButton("Reset Camera")) SetToDefaultValues();
    }

    /// <summary>
    /// Property to change altitude of camera. Angle from XZ plane measured in Euler degrees.
    /// </summary>
    /// <remarks>
    /// Ranges from 90 degrees (i.e. looking down at the target) to -90 degrees (i.e. looking up at the target.)
    /// </remarks>
    public float altitude
    {
        get
        {
            return pivotGO.transform.eulerAngles.x;
        }
        set
        {
            var rotation = pivotGO.transform.localEulerAngles;
            rotation.x = value;
            pivotGO.transform.localEulerAngles = rotation;
        }
    }

    /// <summary>
    /// Property to change zoom of camera. Distance from pivot measured in Unity units.
    /// </summary>
    /// <remarks>
    /// Larger numbers indicate a wider zoom level (e.g. 20 is zoomed out twice as much as 10.)
    /// </remarks>
    public float zoom
    {
        // Zoom levels are stored as negative values because they represent a negative position
        // distance from the pivot. This property handles the negative value aspect and allows
        // all external usage to consider zoom a positive value.
        get
        {
            return -cameraGO.transform.localPosition.z; // negative fix
        }
        set
        {
            var position = cameraGO.transform.localPosition;
            position.z = -Mathf.Clamp(value, minimumZoom, maximumZoom); // negative fix
            cameraGO.transform.localPosition = position;
        }
    }

    /// <summary>
    /// Property to change rotation of camera. Angle around Y axis measured in Euler degrees.
    /// </summary>
    public float rotation
    {
        get
        {
            return transform.localEulerAngles.y;
        }
        set
        {
            var newRotation = transform.localEulerAngles;
            newRotation.y = value;

            // Limit rotation to 0 through 360 degrees.
            if (newRotation.y > 360.0f) newRotation.y -= 360.0f;
            else if (newRotation.y < 0.0f) newRotation.y += 360.0f;

            transform.localEulerAngles = newRotation;
        }
    }

    /// <summary>
    /// Sets altitude, zoom, and rotation to their default values.
    /// </summary>
    public void SetToDefaultValues()
    {
        altitude = defaultAltitude;
        zoom = defaultZoom;
        rotation = defaultRotation;
    }

    /// <summary>
    /// Sets the follow target of the camera controller.
    /// </summary>
    /// <param name="gameObject">The game object the camera controller will follow.</param>
    /// <param name="allowPositionChange">If the camera controller will be forced to follow the game object.</param>
    public void SetTarget(GameObject gameObject, bool allowPositionChange = false)
    {
        targetGO = gameObject;
        this.allowPositionChange = allowPositionChange;
    }

}
