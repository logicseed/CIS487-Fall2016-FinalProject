// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private AgentManager agent;
    public RectTransform healthBar;
    public RectTransform container;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        agent = transform.parent.gameObject.GetComponent<AgentManager>();
        //container = gameObject.GetComponent<RectTransform>();

     }
    private void FixedUpdate () { }
    private void Update () {
        //healthBar.rect.
        healthBar.sizeDelta = new Vector2(2.0f * ((float)agent.health / agent.maximumHealth), 0.25f);
        container.localPosition = new Vector3(0.0f,agent.sphere.radius + 0.25f,0.0f);
        container.LookAt(Camera.main.transform);

     }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
