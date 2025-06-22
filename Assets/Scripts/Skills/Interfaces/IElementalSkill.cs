public interface IElementalSkill {
    void SetPos();
    void SetSize();
    void CastSkill();
    void FinishSkill();
    void DealEleDamage();
    
    void UpdateSkillIcon();
    void UpdateSkillTimerText();
}