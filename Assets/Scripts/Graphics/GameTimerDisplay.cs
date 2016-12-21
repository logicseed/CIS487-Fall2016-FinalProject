// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimerDisplay : MonoBehaviour
{
    public Text displayText;

    public void Update()
    {
        float time = ((GameManager.Instance.gameLength * 60) - GameManager.Instance.gameTimeElapsed);
        displayText.text = "Time Remaining: " + time.ToString("0.00") + " seconds";
    }
}
