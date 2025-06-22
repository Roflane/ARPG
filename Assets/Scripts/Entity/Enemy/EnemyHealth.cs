using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public EnemyStatsManager enemyStats;
    public Int32 expReward;
    
    public delegate void MonsterDefeated(Int32 exp);
    public static event MonsterDefeated OnMonsterDefeated;
    
    void Awake() {
        enemyStats = GetComponent<EnemyStatsManager>();
    }
    
    void Start() {
        enemyStats.currentHealth = enemyStats.maxHealth;
    }

    void FixedUpdate() {
        expReward = RRandom.RandomInt32(1, 3);
    }

    public void ChangeHealth(Int32 amount) {
        enemyStats.currentHealth += amount;
            
        if (enemyStats.currentHealth > enemyStats.maxHealth) {
            enemyStats.currentHealth = enemyStats.maxHealth;
        }
        else if (enemyStats.currentHealth <= 0) {
            OnMonsterDefeated!(expReward);
            Destroy(gameObject);
            ++PlayerStatsManager.Instance.killedCount;
        }
    }
}