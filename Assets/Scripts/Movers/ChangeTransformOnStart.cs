// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Makes instant changes to a GameObjects Transform after loading.
/// </summary>
public class ChangeTransformOnStart : MonoBehaviour
{
    public Vector3 position = Vector3.zero;
    public Vector3 rotation = Vector3.zero;
    public Vector3 scale = Vector3.one;

    private void Start()
    {
        if (position != Vector3.zero) transform.position = position;
        if (rotation != Vector3.zero) transform.eulerAngles = rotation;
        if (scale != Vector3.one) transform.localScale = scale;
    }
}
