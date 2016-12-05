// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class LobbyCharacterGraphics : MonoBehaviour
{
    public float rotationRate = 0.0f;
    private GameObject characterGraphics;

    public void CreateGraphics(GameObject graphics, Color color, float rotation = 0.0f)
    {
        Destroy(characterGraphics);

        characterGraphics = Instantiate(graphics) as GameObject;
        characterGraphics.MakeChildOf(gameObject, "Graphics");

        characterGraphics.transform.Rotate(0.0f, rotation, 0.0f);

        ColorTextures(color);
    }

    public void ColorTextures(Color color)
    {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material.SetColor("_Color", Color.Lerp(Color.white, color, 0.5f) * 0.5f);
            renderer.material.SetColor("_EmissionColor", color * 5.0f);
        }
    }

    public void Update()
    {
        if (characterGraphics != null)
        {
            //characterGraphics.transform.Rotate(0.0f, Time.deltaTime * rotationRate, 0.0f);
            transform.Rotate(0.0f, Time.deltaTime * rotationRate, 0.0f);
        }
    }
}
