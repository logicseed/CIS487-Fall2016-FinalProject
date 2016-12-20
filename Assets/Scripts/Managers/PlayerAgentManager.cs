// Marc King - mjking@umich.edu

using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAgentManager : AgentManager
{
    [HideInInspector]
    public MouseController mouse;
    new public CameraController camera;

    public int character;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        if (type == AgentType.DevPlayer)
        {
            SetupMouseAndCamera();
        }
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        SetupMouseAndCamera();
        this.isPlayer = true;
    }

    public void SetupMouseAndCamera()
    {
        mouse = gameObject.AddComponent<MouseController>();
        camera = Camera.main.transform.parent.parent.GetComponent<CameraController>();
        camera.SetTarget(gameObject);
    }
}
