// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitLobby(GameObject lobby)
    {
        Destroy(lobby);
        LoadScene("MainMenu");
    }

}
