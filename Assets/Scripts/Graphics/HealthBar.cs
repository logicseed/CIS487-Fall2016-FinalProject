// Marc King - mjking@umich.edu

using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private AgentManager agent;
    public RectTransform healthBar;
    public RectTransform container;

    private void Start()
    {
        agent = transform.parent.gameObject.GetComponent<AgentManager>();


    }

    private void Update()
    {
        //healthBar.rect.
        healthBar.sizeDelta = new Vector2(2.0f * ((float)agent.health / agent.maximumHealth), 0.25f);
        container.localPosition = new Vector3(0.0f, agent.sphere.radius + 0.25f, 0.0f);
        container.LookAt(Camera.main.transform);

    }
}
