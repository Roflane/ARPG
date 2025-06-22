using UnityEngine;

public class ToggleSkillTree : MonoBehaviour {
    public CanvasGroup skillCanvas;
    private bool _isOpen;
    
    void Update() {
        if (Input.GetKeyDown(KeyBinds.SkillTree)) {
            if (_isOpen) {
                Time.timeScale = 1;
                skillCanvas.alpha = 0;
                skillCanvas.blocksRaycasts = false;
                _isOpen = false;
            }
            else {
                Time.timeScale = 0;
                skillCanvas.alpha = 1;
                skillCanvas.blocksRaycasts = true;
                _isOpen = true;
            }
        }
    }
}