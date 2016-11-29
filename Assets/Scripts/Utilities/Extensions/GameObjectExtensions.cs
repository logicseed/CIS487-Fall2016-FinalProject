// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public static class GameObjectExtensions
{
    public static Transform FindChildWithTag(this Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.tag == tag)
            {
                return child;
            }
        }
        return null;
    }

    /// <summary>
    /// Makes this GameObject a child of another GameObject and places it at Vector3.zero;
    /// optionally renames this GameObject.
    /// </summary>
    /// <param name="parent">
    /// The GameObject to make this GameObject a child of.
    /// </param>
    /// <param name="name">
    /// Optional name to rename this GameObject to.
    /// </param>
    public static void MakeChildOf(this GameObject child, GameObject parent, string name = "")
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        if (name != "") child.name = name;
    }
}
