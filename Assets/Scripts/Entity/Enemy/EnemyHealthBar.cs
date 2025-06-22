using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    public Slider healthBar;
    public Transform enemyTransform;
    public EnemyStatsManager enemyStats;


    void Awake() {
        enemyStats = GetComponent<EnemyStatsManager>();
    }
    
    void Start() {
        healthBar.maxValue = enemyStats.maxHealth;
        healthBar.value = healthBar.maxValue;
    }
    
    void Update() {
        HandleHealthBarDirection();
        healthBar.value = enemyStats.currentHealth;
    }

    private void HandleHealthBarDirection() {
        switch (enemyTransform.localScale.x) {
            case -1:
                healthBar.direction = Slider.Direction.RightToLeft;
                break;
            case 1:
                healthBar.direction = Slider.Direction.LeftToRight;
                break;
        }
    }
} 