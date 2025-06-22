using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadSceneAsync("Class selection menu");
    }

    public void ExitGame() {
        Application.Quit();
    }
}