using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuiGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
