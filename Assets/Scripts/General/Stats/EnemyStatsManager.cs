using System;
using UnityEngine;

[Serializable]
public class EnemyStatsManager : MonoBehaviour {
    [Header("Movement stats")]
    public Single speed;
    public Int32 facingDirection;

    [Header("Combat stats")]
    public Int32 damage;
    public Int32 currentHealth;
    public Int32 maxHealth;

    [Header("Misc stats")]
    public Single attackRange;
    public Single weaponRange;
    public Single attackCooldown;
    public Single attackCooldownTimer;
    public Single playerDetectionRange;
    public Single knockbackForce;
    public Single stunTime;
}