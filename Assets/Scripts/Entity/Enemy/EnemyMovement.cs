using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private EEnemyState _enemyState;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform _player;
    public Transform detectionPoint;
    public LayerMask playerLayer;
    public EnemyStatsManager enemyStats;

    void Awake() {
        enemyStats = GetComponent<EnemyStatsManager>();
    }
    
    void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ChangeState(EEnemyState.Idle);
    }

    void Update() {
        if (_enemyState == EEnemyState.Knockback) return;
        
        HandleAttackCooldown();
        CheckForPlayer();
        HandleEnemyState();
    }

    private void HandleAttackCooldown() {
        if (enemyStats.attackCooldownTimer > 0) {
            enemyStats.attackCooldownTimer -= Time.deltaTime;
        }
    }
    
    private void HandleEnemyState() {
        switch (_enemyState) {
            case EEnemyState.Chasing:
                Chase();
                break;
            case EEnemyState.Attacking:
                _rb.linearVelocity = Vector2.zero;
                break;
        }
    }
    
    private void CheckForPlayer() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position,
            enemyStats.playerDetectionRange, playerLayer);

        if (hits.Length > 0) {
            _player = hits[0].transform;

            if (Vector2.Distance(transform.position, _player.position) < enemyStats.attackRange &&
                enemyStats.attackCooldownTimer <= 0) {
                enemyStats.attackCooldownTimer = enemyStats.attackCooldown;
                ChangeState(EEnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, _player.position) > enemyStats.attackRange &&
                     _enemyState != EEnemyState.Attacking) {
                ChangeState(EEnemyState.Chasing);
            }

        }
        else {
            enemyStats.attackCooldownTimer = enemyStats.attackCooldown;
            _rb.linearVelocity = Vector2.zero;
            ChangeState(EEnemyState.Idle);
        }
    }

    private void Flip() {
        enemyStats.facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Chase() {
        if (_player.position.x > transform.position.x && enemyStats.facingDirection == -1 ||
            _player.position.x < transform.position.x && enemyStats.facingDirection == 1) {
            Flip();
        }

        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.linearVelocity = direction * enemyStats.speed;
    }

    public void ChangeState(EEnemyState newState) {
        if (_enemyState == EEnemyState.Idle) {
            _anim.SetBool(EnemyAnimatorData.IsIdle, false);
        }
        else if (_enemyState == EEnemyState.Chasing) {
            _anim.SetBool(EnemyAnimatorData.IsWalking, false);
        }
        else if (_enemyState == EEnemyState.Attacking) {
            _anim.SetBool(EnemyAnimatorData.IsAttacking, false);
        }

        _enemyState = newState;

        if (_enemyState == EEnemyState.Idle) {
            _anim.SetBool(EnemyAnimatorData.IsIdle, true);
        }
        else if (_enemyState == EEnemyState.Chasing) {
            _anim.SetBool(EnemyAnimatorData.IsWalking, true);
        }
        else if (_enemyState == EEnemyState.Attacking) {
            _anim.SetBool(EnemyAnimatorData.IsAttacking, true);
        }
    }
}


public enum EEnemyState : sbyte {
    Idle,
    Chasing,
    Attacking,
    Knockback
}