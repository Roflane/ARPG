using UnityEngine;

public static class PlayerAnimatorData {
    public static readonly int Horizontal = Animator.StringToHash("horizontal");
    public static readonly int Vertical = Animator.StringToHash("vertical");
    public static readonly int IsBasicAttack = Animator.StringToHash("IsBasicAttack");
    public static readonly int IsShooting = Animator.StringToHash("IsShooting");
    public static readonly int AimX = Animator.StringToHash("aimX");
    public static readonly int AimY = Animator.StringToHash("aimY");
    
    public static readonly int IsFireCasted = Animator.StringToHash("IsFireCasted");
    public static readonly int IsIceCasted = Animator.StringToHash("IsIceCasted");
    public static readonly int IsLightningCasted = Animator.StringToHash("IsLightningCasted");
}