using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour {
    public List<SkillSlot> prerequisiteSkillSlots;
    public SkillSO skillSo;
    public Image skillIcon;
    public TMP_Text skillLevelText;
    public Button skillButton;
    public int currentLevel;
    public bool isUnlocked;
    
    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;

    private void OnValidate() {
        if (skillSo && skillLevelText) {
            UpdateUI();
        }
    }

    public bool CanUnlockSkill() {
        foreach (SkillSlot slot in prerequisiteSkillSlots) {
            if (slot.isUnlocked && slot.currentLevel == skillSo.maxLevel) return true;
        }
        return false;
    }
    
    public void Unlock() {
        isUnlocked = true;
        UpdateUI(); 
    }

    public void TryUpgradeSkill() {
        if (isUnlocked && currentLevel < skillSo.maxLevel) {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);
            
            if (currentLevel >= skillSo.maxLevel) {
                OnSkillMaxed?.Invoke(this);
            }
            UpdateUI();
        }
    }

    private void UpdateUI() {
        skillIcon.sprite = skillSo.skillIcon;

        if (isUnlocked) {
            skillButton.interactable = true;
            skillLevelText.text = $"{currentLevel} / {skillSo.maxLevel}";
            skillIcon.color = Color.white;
        }
        else {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            skillIcon.color = new Color(10, 10, 10, 0.73f);
        }

        skillLevelText.color = Color.black;
    }
}