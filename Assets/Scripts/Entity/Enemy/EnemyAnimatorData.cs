using UnityEngine;

public static class EnemyAnimatorData {
    public static readonly int IsIdle = Animator.StringToHash("IsIdle");
    public static readonly int IsWalking = Animator.StringToHash("IsWalking");
    public static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
}