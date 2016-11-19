// Marc King - mjking@umich.edu

using UnityEngine;

[RequireComponent(typeof(MouseController))]
[DisallowMultipleComponent]
public class PlayerAgentManager : AgentManager
{
    public MouseController mouse;

    protected override void Start()
    {
        base.Start();
        mouse = gameObject.GetComponent<MouseController>();
        this.isPlayer = true;
    }
}
