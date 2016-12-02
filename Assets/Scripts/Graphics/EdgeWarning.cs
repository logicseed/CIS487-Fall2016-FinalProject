// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class EdgeWarning : MonoBehaviour
{
    public float range;
    public float scrollRate;
    
    public GameObject graphics;
    private Renderer meshRenderer;

    public float flashRate;
    private int flashDirection = 1;
    public float flashBright;
    public float flashDim;
    public Color flashColor;
    private float flashValue;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () 
    {
        meshRenderer = graphics.GetComponent<Renderer>();
        graphics.transform.Translate(0.0f, 0.0f, range, Space.World);
        meshRenderer.enabled = true;

        flashValue = (flashBright + flashDim) / 2;
     }
    private void FixedUpdate ()
    {
        
    }
    private void Update () 
    {
        gameObject.transform.LookAt(Camera.main.transform.parent);
        // scroll 
        var offset = meshRenderer.material.GetTextureOffset("_MainTex").x;
        offset += Time.deltaTime * (scrollRate / 100.0f);
        if (offset > 1.0f) offset--;
        meshRenderer.material.SetTextureOffset("_MainTex",new Vector2(offset, 0.0f));

        // flash
        if (flashValue > flashBright) flashDirection = -1;
        else if (flashValue < flashDim) flashDirection = 1;

        flashValue = flashValue + (Time.deltaTime * flashRate * flashDirection);
        meshRenderer.material.SetColor("_EmissionColor", flashColor * flashValue);
     }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
