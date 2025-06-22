using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSelectionMenu : MonoBehaviour {
    public static EClass SelectedClass { get; private set; }

    public void SelectKnight() {
        SelectedClass = EClass.Knight;
        SceneManager.LoadScene("Game");
    }

    public void SelectArcher() {
        SelectedClass = EClass.Archer;
        SceneManager.LoadScene("Game");
    }
}

public enum EClass : sbyte {
    Knight, 
    Archer
} 