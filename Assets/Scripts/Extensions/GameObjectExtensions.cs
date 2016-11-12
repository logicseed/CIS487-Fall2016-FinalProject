// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public static class GameObjectExtensions
{
    public static Transform FindChildWithTag (this Transform parent, string tag)
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
}
