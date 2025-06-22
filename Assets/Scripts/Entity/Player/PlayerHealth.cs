using System;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour {
    public TMP_Text healthText;
    public Animator healthTextAnim;
        
    void Start() {
        PlayerStatsManager.Instance.currentHealth = PlayerStatsManager.Instance.maxHealth;
    }
        
    void FixedUpdate() {
        healthText.text = $"HP: {PlayerStatsManager.Instance.currentHealth} / {PlayerStatsManager.Instance.maxHealth}";
    }

    private void PlayHpAnimation() {
        healthTextAnim.Play("HPText");
    }
    
    public void ChangeHealth(Int32 amount) {
        PlayerStatsManager.Instance.currentHealth += amount;
        if (PlayerStatsManager.Instance.currentHealth <= 0) {
            SceneManager.LoadScene("Scenes/Defeat Window");
        }
        PlayHpAnimation();
    }
}