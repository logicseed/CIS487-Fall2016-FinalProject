// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Displays a warning billboard to indicate the intended boundaries of a level.
/// </summary>
public class EdgeWarning : MonoBehaviour
{
    [Tooltip("Warning billboard game object.")]
    public GameObject graphics;
    [Tooltip("Color of the warning billboard.")]
    public Color color;

    [Space(5)]

    [Tooltip("How far from the origin the edge warning will appear.")]
    [Range(100.0f, 2000.0f)]
    public float range;

    [Space(5)]

    [Tooltip("Number of scrolls per second.")]
    [Range(0.0f, 10.0f)]
    public float scrollRate;

    [Space(5)]

    [Tooltip("Number of flashes per second.")]
    [Range(0.0f, 10.0f)]
    public float flashRate;
    [Tooltip("Dimmest intensity of the flash.")]
    [Range(0.0f, 5.0f)]
    public float flashDim;
    [Tooltip("Brightest intensity of the flash.")]
    [Range(0.0f, 5.0f)]
    public float flashBright;
    
    
    private int flashDirection = 1; // Flash gets brighter when positive, dimmer when negative
    private float flashValue; // Current intensity level of the emission texture
    private Renderer meshRenderer;

    private void Start()
    {
        // Get renderer reference to make material changes more efficient
        meshRenderer = graphics.GetComponent<Renderer>();
        meshRenderer.enabled = true;

        // Place the graphic at the specified range
        graphics.transform.Translate(0.0f, 0.0f, range, Space.World);
        
        // Start the flashing at an average intensity
        flashValue = (flashBright + flashDim) / 2;
    }

    private void Update()
    {
        // rotate
        gameObject.transform.LookAt(Camera.main.transform.parent);

        // scroll 
        var offset = meshRenderer.material.GetTextureOffset("_MainTex").x;
        offset += Time.deltaTime * (scrollRate / meshRenderer.material.GetTextureScale("_MainTex").x);
        if (offset > 1.0f) offset--; // Make sure the offset doesn't get large enough for precision errors
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));

        // flash
        if (flashValue > flashBright) flashDirection = -1;
        else if (flashValue < flashDim) flashDirection = 1;
        flashValue = flashValue + (Time.deltaTime * flashRate * flashDirection);
        meshRenderer.material.SetColor("_EmissionColor", color * flashValue);
    }
}
