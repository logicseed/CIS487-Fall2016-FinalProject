// Marc King - mjking@umich.edu

using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    [Tooltip("Amount of rotation around each axis over time.")]
    public Vector3 rotation;

    #region MonoBehavior Methods

    private void Update () 
    { 
        transform.Rotate(rotation * Time.deltaTime);
    }

    #endregion MonoBehaviour Methods
}
