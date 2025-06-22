using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour, IElementalSkill {
    private float _fireTimer;
    private sbyte _fireTimerCounter;
    public SpriteRenderer fireSprite;
    public Animator anim;
    public Transform player;
    public Transform firePoint;
    public LayerMask enemyLayer;
    public Image fireImage;
    public TMP_Text fireTimerText;

    void Update() {
        _fireTimer -= Time.deltaTime;
        CastSkill();
        SetSize();
        UpdateSkillIcon(); 
        UpdateSkillTimerText();
    }

    public void SetSize() {
        transform.localScale = new(PlayerStatsManager.Instance.fireScale, 
            PlayerStatsManager.Instance.fireScale, transform.localScale.z);
    }

    public void SetPos() {
        float fireOffset = PlayerStatsManager.Instance.facingDirection * 4;
        Vector3 firePos = new(player.transform.position.x + fireOffset, player.transform.position.y, player.transform.position.z);
        transform.position = firePos;
    }

    public void CastSkill() {
        if (Input.GetKeyDown(KeyBinds.Fire) && _fireTimer <= 0) {
            SetPos();
            fireSprite.color = Color.white;
            anim.SetBool(PlayerAnimatorData.IsFireCasted, true);
            DealEleDamage();
            _fireTimer = PlayerCooldown.Fire;
        }
    }

    public void DealEleDamage() {
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] enemies = Physics2D.OverlapCircleAll(firePoint.position, PlayerStatsManager.Instance.weaponRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<EnemyHealth>().ChangeHealth(-PlayerStatsManager.Instance.damage);
        }
    }

    public void FinishSkill() {
        fireSprite.color = new Color(0, 0, 0, 0);
        anim.SetBool(PlayerAnimatorData.IsFireCasted, false);
    }
    
    public void UpdateSkillIcon() {
        if (_fireTimer <= 0) {
            fireImage.color = Color.white;
        }
        else fireImage.color = new (1f, 1f, 1f, 0.5f);
    }

    public void UpdateSkillTimerText() {
        _fireTimerCounter = (sbyte)_fireTimer;
        if (_fireTimer <= 0) {
            fireTimerText.enabled = false;
            _fireTimerCounter = 0;
        }
        else {
            fireTimerText.enabled = true;
            fireTimerText.text = $"{_fireTimerCounter + 1}";
        }
    }
}