// Marc King - mjking@umich.edu

using UnityEngine;

[RequireComponent(typeof(MouseController))]
[DisallowMultipleComponent]
public class PlayerAgentManager : AgentManager
{
    [HideInInspector]
    public MouseController mouse;

    public GameObject cameraPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnStartLocalPlayer()
    {
        mouse = gameObject.GetComponent<MouseController>();
        var cameraController = Instantiate(cameraPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        cameraController.GetComponent<CameraController>().SetTarget(gameObject);
        this.isPlayer = true;
    }
}
