// Marc King - mjking@umich.edu

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("GameObjects")]
    [Tooltip("The child Camera of this controller.")]
    public GameObject cameraGO;
    [Tooltip("The object to follow while not in free explore.")]
    public GameObject targetGO;

    private Transform pivot;

    [Header("Allow Change")]
    [Tooltip("Allows the controller to change the altitude of the camera.")]
    public bool allowAltitudeChange = true;
    [Tooltip("Allows the controller to change the zoom level of the camera.")]
    public bool allowZoomChange = true;
    [Tooltip("Allows the controller to change the position of the camera. " +
             "Default whenever the target is null.")]
    public bool allowPositionChange = true;

    [Header("Rates of Change")]
    [Tooltip("How quickly the altitude will change.")]
    [Range(0.0f, 100.0f)]
    public float altitudeRate = 10;
    [Tooltip("How quickly the rotation will change.")]
    [Range(0.0f, 100.0f)]
    public float rotationRate = 10;
    [Tooltip("How quickly the zoom will change.")]
    [Range(0.0f, 100.0f)]
    public float zoomRate = 10;
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

    private void Start()
    {
        pivot = cameraGO.transform.parent;

        ResetZoom();
        ResetRotation();
        ResetAltitude();
    }

    private void Update()
    {
        if (targetGO == null) allowPositionChange = true;

        if (allowAltitudeChange && Input.GetAxis("UpDown Camera") != 0.0f)
        {
            ChangeAltitude(Input.GetAxis("UpDown Camera") * altitudeRate);
        }

        if (Input.GetAxis("Rotate Camera") != 0.0f)
        {
            ChangeRotation(Input.GetAxis("Rotate Camera") * rotationRate);
        }

        if (allowZoomChange && Input.GetAxis("Zoom Camera") != 0.0f)
        {
            ChangeZoom(Input.GetAxis("Zoom Camera") * zoomRate);
        }

        if (allowPositionChange)
        {
            transform.Translate(Input.GetAxis("LeftRight Camera") * moveRate,
                0.0f,
                Input.GetAxis("ForwardBack Camera") * moveRate);
        }
        else
        {
            transform.position = targetGO.transform.position;
        }
    }

    public float GetAltitude()
    {
        return pivot.transform.eulerAngles.x;
    }

    public void SetAltitude(float altitude)
    {
        var rotation = pivot.transform.localEulerAngles;
        rotation.x = altitude;
        pivot.transform.localEulerAngles = rotation;
    }

    public void ChangeAltitude(float amount)
    {
        SetAltitude(GetAltitude() + amount);
    }

    public void ResetAltitude()
    {
        SetAltitude(defaultAltitude);
    }

    public float GetZoom()
    {
        return cameraGO.transform.localPosition.z;
    }

    public void SetZoom(float zoom)
    {
        var position = cameraGO.transform.localPosition;
        position.z = Mathf.Clamp(zoom, -maximumZoom, -minimumZoom);
        cameraGO.transform.localPosition = position;
    }

    public void ChangeZoom(float amount)
    {
        SetZoom(GetZoom() + amount);
    }

    public void ResetZoom()
    {
        SetZoom(-defaultZoom);
    }

    public float GetRotation()
    {
        return transform.localEulerAngles.y;
    }

    public void SetRotation(float rotation)
    {
        var newRotation = transform.localEulerAngles;
        newRotation.y = rotation;
        transform.localEulerAngles = newRotation;
    }

    public void ChangeRotation(float amount)
    {
        var rotation = GetRotation() + amount;
        if (rotation > 360.0f) rotation -= 360.0f;
        else if (rotation < 0.0f) rotation += 360.0f;
        SetRotation(rotation);
    }

    public void ResetRotation()
    {
        SetRotation(defaultRotation);
    }

}
