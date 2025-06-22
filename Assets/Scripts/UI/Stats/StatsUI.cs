using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour {
    public GameObject[] statSlots;
    public CanvasGroup statsCanvas;
    
    void Start() {
        UpdateAllStats();
    }

    void Update() {
        if (Input.GetKeyDown(KeyBinds.Stats)) {
            if (statsCanvas.alpha is 1) {
                statsCanvas.alpha = 0;
                Time.timeScale = 1;
            }
            else {
                statsCanvas.alpha = 1;
                Time.timeScale = 0;
            }
        }
    }
    
    private void UpdateDamage() {
        statSlots[0].GetComponentInChildren<TMP_Text>().text = $"Damage: {PlayerStatsManager.Instance.damage}";
    }
    
    private void UpdateSpeed() {
        statSlots[1].GetComponentInChildren<TMP_Text>().text = $"Speed: {PlayerStatsManager.Instance.speed}";
    }

    private void UpdateAllStats() {
        UpdateDamage();
        UpdateSpeed();
    }
}