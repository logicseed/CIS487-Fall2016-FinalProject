using UnityEngine;
using System.Collections;

public class SelfTrigger : MonoBehaviour
{
    [HideInInspector]
    public GameObject abilityObject;

    void start()
    {
        //ability object = player
        //Get players stats/hp/shields
    }

    public void cast(int effect)
    {
        if (effect == 1)
        {
            //Do stuff with shields
        }
        else if (effect == 2)
        {
            //Do stuff with stats (buffs)
        }
        else if (effect == 5)
        {
            //Do stuff with movement? 
        }
    }
}
