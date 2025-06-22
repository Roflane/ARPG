using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour {
    private Rigidbody2D _rb;
    private EnemyMovement _enemyMovement;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }
        
    public void KnockBack(Transform forceTransform, float knockbackForce, float stunTime) {
        _enemyMovement.ChangeState(EEnemyState.Knockback);
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction = (transform.position - forceTransform.position).normalized;
        _rb.linearVelocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        _rb.linearVelocity = Vector2.zero;
        _enemyMovement.ChangeState(EEnemyState.Idle);
    }
}