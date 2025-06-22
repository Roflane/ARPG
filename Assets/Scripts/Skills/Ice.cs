using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ice : MonoBehaviour, IElementalSkill {
    private float _iceTimer;
    private sbyte _iceTimerCounter;
    public SpriteRenderer iceSprite;
    public Animator anim;
    public Transform player;
    public Transform icePoint;
    public LayerMask enemyLayer;
    public Image iceImage;
    public TMP_Text iceTimerText;

    void Update() {
        _iceTimer -= Time.deltaTime;
        SetSize();
        CastSkill();
        UpdateSkillIcon();
        UpdateSkillTimerText();
    }

    public void SetSize() {
        transform.localScale = new(PlayerStatsManager.Instance.iceScale, 
            PlayerStatsManager.Instance.iceScale, transform.localScale.z);
    }

    public void SetPos() {
        float iceOffset = PlayerStatsManager.Instance.facingDirection * 4;
        Vector3 icePos = new(player.transform.position.x + iceOffset, player.transform.position.y, player.transform.position.z);
        transform.position = icePos;
    }

    public void CastSkill() {
        if (Input.GetKeyDown(KeyBinds.Ice) && _iceTimer <= 0) {
            SetPos();
            iceSprite.color = Color.white;
            anim.SetBool(PlayerAnimatorData.IsIceCasted, true);
            DealEleDamage();
            _iceTimer = PlayerCooldown.Ice;
        }
    }

    public void DealEleDamage() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] enemies = Physics2D.OverlapCircleAll(icePoint.position, PlayerStatsManager.Instance.weaponRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<EnemyHealth>().ChangeHealth(-PlayerStatsManager.Instance.damage);
        }
    }

    public void FinishSkill() {
        iceSprite.color = new Color(0, 0, 0, 0);
        anim.SetBool(PlayerAnimatorData.IsIceCasted, false);
    }
    
    public void UpdateSkillIcon() {
        if (_iceTimer <= 0) {
            iceImage.color = Color.white;
        }
        else iceImage.color = new (1f, 1f, 1f, 0.5f);
    }

    public void UpdateSkillTimerText() {
        _iceTimerCounter = (sbyte)_iceTimer;
        if (_iceTimer <= 0) {
            iceTimerText.enabled = false;
            _iceTimerCounter = 0;
        }
        else {
            iceTimerText.enabled = true;
            iceTimerText.text = $"{_iceTimerCounter + 1}";
        }
    }
}