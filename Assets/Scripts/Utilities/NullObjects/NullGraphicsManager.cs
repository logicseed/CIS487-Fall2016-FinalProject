// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Null-safe GraphicsManager.
/// </summary>
public class NullGraphicsManager : GraphicsManager
{
    //private AgentManager agent;
    private GameObject graphicsGameObject;

    private void Start()
    {
        //agent = gameObject.GetComponent<AgentManager>();

        graphicsGameObject = new GameObject();
        graphicsGameObject.transform.parent = gameObject.transform;
        graphicsGameObject.transform.localPosition = Vector3.zero;
        graphicsGameObject.name = "Graphics";
    }
}
