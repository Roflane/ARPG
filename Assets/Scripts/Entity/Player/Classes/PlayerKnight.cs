
using UnityEngine;

public class PlayerKnight : MonoBehaviour {
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        if (PlayerStatsManager.Instance.weaponRange > 0 && attackPoint) {
            Gizmos.DrawWireSphere(attackPoint.position, PlayerStatsManager.Instance.weaponRange);
        }
    }

    public void Attack() {
        if (!enabled) return;
        anim.SetBool(PlayerAnimatorData.IsBasicAttack, true);
    }

    public void DealDamage() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, PlayerStatsManager.Instance.weaponRange, enemyLayer);

        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<EnemyHealth>().ChangeHealth(-PlayerStatsManager.Instance.damage);
        }
    }
        
    public void FinishAttack() {
        if (!enabled) return;
        anim.SetBool(PlayerAnimatorData.IsBasicAttack, false);
    }

    public void ResetAnimations() {
        anim.SetBool(PlayerAnimatorData.IsBasicAttack, false);
    }
}