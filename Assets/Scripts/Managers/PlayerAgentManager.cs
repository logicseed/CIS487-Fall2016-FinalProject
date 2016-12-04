// Marc King - mjking@umich.edu

using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAgentManager : AgentManager
{
    [HideInInspector]
    public MouseController mouse;

    //public GameObject cameraPrefab;

    //public Camera networkCamera;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnStartLocalPlayer()
    {
        mouse = gameObject.GetComponent<MouseController>();
        //var cameraController = Instantiate(cameraPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //cameraController.GetComponent<CameraController>().SetTarget(gameObject);
        //networkCamera = cameraController.GetComponent<Camera>();
        this.isPlayer = true;
    }
}
