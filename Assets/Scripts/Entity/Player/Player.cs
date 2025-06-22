using UnityEngine;

public class Player : MonoBehaviour {
    void Awake() {
        SelectClass();
    }


    private void SelectClass() {
        switch (ClassSelectionMenu.SelectedClass) {
            case EClass.Knight:
                GetComponent<PlayerKnight>().enabled = true;
                GetComponent<PlayerArcher>().enabled = false;
                break;
            case EClass.Archer:
                GetComponent<PlayerArcher>().enabled = true;
                GetComponent<PlayerKnight>().enabled = false;
                break;
        }
    }
}