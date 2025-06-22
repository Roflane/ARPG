using UnityEngine;

public class SkillManager : MonoBehaviour {
    void OnEnable() {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    
    void OnDestroy() {  
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }
    
    private void HandleAbilityPointSpent(SkillSlot slot) {
        string skillName = slot.skillSo.skillName;
    
        switch (skillName) {
            case "Max Health Boost":
                PlayerStatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "Blink Skill Boost":
                PlayerStatsManager.Instance.UpdateBlinkSkill(0.2f);
                break;
            case "Fire Skill Boost":
                PlayerStatsManager.Instance.UpdateFireSkill(1.273f);
                break;
            case "Ice Skill Boost":
                PlayerStatsManager.Instance.UpdateIceSkill(1.231f);
                break;
            case "Lightning Skill Boost":
                PlayerStatsManager.Instance.UpdateLightningSkill(1.173f);
                break;
            default:
                Debug.LogWarning("Unknown skill: " + skillName);   
                break;
        }
    }
}