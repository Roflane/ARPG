using System;
using TMPro;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    public static PlayerStatsManager Instance;
    public TMP_Text healthText;
    
    [Header("Movement stats")]
    public Single speed;
    public Int32 facingDirection;

    [Header("Base stats")]
    public Int32 damage;
    public Int32 currentHealth;
    public Int32 maxHealth;
    
    [Header("Combat stats")]
    public Single blinkDistance;
    
    [Header("Magic stats")] 
    public Single fireScale;
    public Single iceScale;
    public Single lightningScale;

    [Header("Misc stats")]
    public Single attackRange;
    public Single weaponRange;
    public Single attackCooldown;
    public Single attackCooldownTimer;
    public Single knockbackForce;
    public Single stunTime;

    [Header("Statistics")]
    public Int32 killedCount;

    void Awake() {
        if (!Instance) Instance = this;
        else Destroy(this);
    }

    public void UpdateMaxHealth(Int32 amount) {
        maxHealth += amount;      
        healthText.text = $"HP: {currentHealth} / {maxHealth}";
        // Debug.Log("Max Health: " + maxHealth);
    }

    public void UpdateBlinkSkill(Single x) => blinkDistance += x;
    
    public void UpdateFireSkill(Single scale) => fireScale *= scale;      
    public void UpdateIceSkill(Single scale) => iceScale *= scale;      
    public void UpdateLightningSkill(Single scale) => lightningScale *= scale;
}