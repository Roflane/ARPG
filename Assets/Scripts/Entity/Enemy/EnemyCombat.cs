using UnityEngine;

public class EnemyCombat  : MonoBehaviour { 
    public Transform attackPoint;
    public LayerMask playerLayer;
    public EnemyStatsManager enemyStats;

    void Awake() {
        enemyStats = GetComponent<EnemyStatsManager>();
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        if (enemyStats.weaponRange > 0) {
            Gizmos.DrawWireSphere(attackPoint.position, enemyStats.weaponRange);
        }
    }
        
    public void Attack() {
        Invoke(nameof(DelayedAttack), 0.3f);
    }
    
    public void DelayedAttack() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, enemyStats.weaponRange, playerLayer);
            
        if (hits.Length > 0) {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-enemyStats.damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, enemyStats.knockbackForce, enemyStats.stunTime);
        }
    }
}