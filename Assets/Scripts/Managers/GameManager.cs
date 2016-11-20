// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake ()
    {
        if (instance == null) instance = this; 
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
