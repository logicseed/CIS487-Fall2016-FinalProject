// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private AgentManager agent;
    public RectTransform healthBar;
    public RectTransform container;
    public Camera cameraToFace;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        agent = transform.parent.gameObject.GetComponent<AgentManager>();
        //container = gameObject.GetComponent<RectTransform>();

     }
    private void FixedUpdate () { }
    private void Update () {
        //healthBar.rect.
        healthBar.sizeDelta = new Vector2(2.0f * ((float)agent.currentHealth / agent.health), 0.25f);
        container.localPosition = new Vector3(0.0f,agent.sphere.radius + 0.25f,0.0f);

        // if (cameraToFace == null)
        // {
        //     var players = GameObject.FindGameObjectsWithTag("Player");
        //     foreach (var player in players)
        //     {
        //         if (player.GetComponent<AgentManager>().isLocalPlayer)
        //         {
        //             cameraToFace = player.GetComponentInChildren<Camera>();
        //         }
        //     }
        // }
        // // face camera
        // container.LookAt(cameraToFace.transform);

     }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
