using UnityEngine;
using System.Collections.Generic;

public class SelfBehavior : MonoBehaviour
{
    AgentManager agent;
    AutoAttack auto;
    public List <string> buff;
    public List <float> duration;
    internal List<SelfProperties.toBuff> buffList;

    void start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        auto = gameObject.GetComponent<AutoAttack>();
    }

    public void cast()
    {
        for(int i = 0; i < buff.Count; i++)
        {
            if(buffList[i].ToString() == "Shields")
            {

            }




        }
    }
}
