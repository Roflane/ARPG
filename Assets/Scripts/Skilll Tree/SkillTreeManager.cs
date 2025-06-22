using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour {
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints = 5;

    void Start() {
        foreach (SkillSlot slot in skillSlots) {
            slot.skillButton.onClick.AddListener(() => CheckAvailablePoints(slot));
        }
        UpdateAbilityPoints(5);
    }
    
    void OnEnable() {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
        ExpManager.OnLevelUp += UpdateAbilityPoints;
    } 
    
    void OnDisable() {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
        ExpManager.OnLevelUp -= UpdateAbilityPoints;
    }

    private void CheckAvailablePoints(SkillSlot slot) {
        if (availablePoints > 0) {
            slot.TryUpgradeSkill();
        }
    }
    
    private void HandleAbilityPointsSpent(SkillSlot skillSlot) {
        if (availablePoints > 0) {
            UpdateAbilityPoints(-1);
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot) {
        foreach (SkillSlot slot in skillSlots) {
            if (slot.CanUnlockSkill()) {
                slot.Unlock();
                Debug.Log("HandleSkillMaxed (if)");
            }
        }
        Debug.Log("HandleSkillMaxed");
    }

    private void UpdateAbilityPoints(int amount) {
        availablePoints += amount;
        pointsText.text = $"Skill Points: {availablePoints}";
    }
}