// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    public void Update()
    {
        var text = "";
        text += "<b>Resources Collected from Captured Planets</b>\n\n";
		text += GameManager.Instance.teamNames[(int)TeamType.Team1] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team1].ToString("0") + "\n";
		text += GameManager.Instance.teamNames[(int)TeamType.Team2] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team2].ToString("0") + "\n";
		text += GameManager.Instance.teamNames[(int)TeamType.Team3] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team3].ToString("0") + "\n";
		text += GameManager.Instance.teamNames[(int)TeamType.Team4] + " - " + GameManager.Instance.teamScores[(int)TeamType.Team4].ToString("0") + "\n";

		scoreText.text = text;
    }
}
