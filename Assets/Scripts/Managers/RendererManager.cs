// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Manages all of the renderers that make up the graphics of an agent.
/// </summary>
public class RendererManager : MonoBehaviour
{
    private Component[] renderers;

    private void Awake()
    {
        renderers = gameObject.GetComponentsInChildren(typeof(Renderer));
    }

    /// <summary>
    /// Sets the color of the albedo texture.
    /// </summary>
    /// <param name="color">Color to tint the texture with.</param>
    public void SetPaintColor(Color color)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.SetColor("_Color", color);
        }
    }

    /// <summary>
    /// Sets the color of the emissive texture.
    /// </summary>
    /// <param name="color">Color to tint the texture with.</param>
    public void SetTeamColor(Color color)
    {
        var lightIntensity = GameManager.instance.lightIntensity;

        foreach (Renderer renderer in renderers)
        {
            renderer.material.SetColor("_EmissionColor", color * lightIntensity);
        }
    }
}
