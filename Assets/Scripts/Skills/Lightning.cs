using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lightning : MonoBehaviour, IElementalSkill {
    private float _lightningTimer;
    private sbyte _lightningTimerCounter;
    public SpriteRenderer lightningSprite;
    public Animator anim;
    public Transform player;
    public Transform lightningPoint;
    public LayerMask enemyLayer;
    public Image lightningImage;
    public TMP_Text lightningTimerText;

    void Update() {
        _lightningTimer -= Time.deltaTime;
        CastSkill();
        SetSize();
        UpdateSkillIcon();
        UpdateSkillTimerText();
    }
    
    public void SetSize() {
        transform.localScale = new(PlayerStatsManager.Instance.lightningScale, 
            PlayerStatsManager.Instance.lightningScale, transform.localScale.z);
    }

    public void SetPos() {
        float lightningOffset = PlayerStatsManager.Instance.facingDirection * 4;
        Vector3 lightningPos = new(player.transform.position.x + lightningOffset, player.transform.position.y, player.transform.position.z);
        transform.position = lightningPos;
    }

    public void CastSkill() {
        if (Input.GetKeyDown(KeyBinds.Lightning) && _lightningTimer <= 0) {
            SetPos();
            lightningSprite.color = Color.white;
            anim.SetBool(PlayerAnimatorData.IsLightningCasted, true);
            DealEleDamage();
            _lightningTimer = PlayerCooldown.Lightning;
        }
    }

    public void DealEleDamage() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] enemies = Physics2D.OverlapCircleAll(lightningPoint.position, PlayerStatsManager.Instance.weaponRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<EnemyHealth>().ChangeHealth(-PlayerStatsManager.Instance.damage);
        }
    }

    public void FinishSkill() {
        lightningSprite.color = new Color(0, 0, 0, 0);
        anim.SetBool(PlayerAnimatorData.IsLightningCasted, false);
    }
    
    public void UpdateSkillIcon() {
        if (_lightningTimer <= 0) {
            lightningImage.color = Color.white;
        }
        else lightningImage.color = new (1f, 1f, 1f, 0.5f);
    }

    public void UpdateSkillTimerText() {
        _lightningTimerCounter = (sbyte)_lightningTimer;
        if (_lightningTimer <= 0) {
            lightningTimerText.enabled = false;
            _lightningTimerCounter = 0;
        }
        else {
            lightningTimerText.enabled = true;
            lightningTimerText.text = $"{_lightningTimerCounter + 1}";
        }
    }
}