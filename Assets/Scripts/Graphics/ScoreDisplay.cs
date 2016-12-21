// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    public void Update()
    {
        var text = "";
        text += "<b>Scores</b>\n\n";
        text += GameManager.Instance.teamNames[(int)TeamType.Team1] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team1] + "\n";
        text += GameManager.Instance.teamNames[(int)TeamType.Team2] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team2] + "\n";
        text += GameManager.Instance.teamNames[(int)TeamType.Team3] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team3] + "\n";
        text += GameManager.Instance.teamNames[(int)TeamType.Team4] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team4] + "\n";
    }
}
