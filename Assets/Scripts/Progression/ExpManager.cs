using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ExpManager : MonoBehaviour {
    public Int32 level;
    public Single currentExp;
    public Single expToLevel;
    public Single expGrowthMultiplier = 1.2f;
    public Slider expSlider;
    public TMP_Text levelText;

    public static event Action<int> OnLevelUp;
    
    void Start() {
        UpdateUI();
    }

    void Update() {
        HandleVictory();
    }

    private void OnEnable() {
        EnemyHealth.OnMonsterDefeated += GainExperience;
    }
    
    private void OnDisable() {
        EnemyHealth.OnMonsterDefeated -= GainExperience;
    }
    
    
    private void LevelUp() {
        level++;
        currentExp -= expToLevel;
        expToLevel *= expGrowthMultiplier;
        OnLevelUp?.Invoke(1);
    }
    
    private void GainExperience(Int32 amount) {
        currentExp += amount;
        if (currentExp >= expToLevel) {
            LevelUp();
        }
        UpdateUI();
    }

    private void UpdateUI() {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        levelText.text = $"Level: {level}";
    }

    private void HandleVictory() {
        if (level == 10) {
            SceneManager.LoadScene("Scenes/Victory Window");
        }
    }
}