// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.UI;

public class UnitPlaque : MonoBehaviour
{
    private AgentManager agent;
    public RectTransform container;
    public RectTransform healthBar;
    public RectTransform shieldsBar;
    public Text playerName;

    private void Start()
    {
        agent = transform.parent.gameObject.GetComponent<AgentManager>();

        if (agent.isPlayer)
        {
            playerName.text = GameManager.Instance.teamNames[(int)agent.team];
        }
    }

    private void Update()
    {
        // Update health and shields
        healthBar.sizeDelta = new Vector2(2.0f * ((float)agent.health / agent.maximumHealth), 0.25f);
        shieldsBar.sizeDelta = new Vector2(2.0f * ((float)agent.shields / agent.maximumShields), 0.25f);
        
        // Update facing
        container.localPosition = new Vector3(0.0f, agent.sphere.radius + 0.25f, 0.0f);
        container.LookAt(Camera.main.transform);
    }
}
