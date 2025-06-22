using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private PlayerKnight _knight;        
    private bool _isKnockedBack;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isShooting;

    void Awake() {
        _knight = GetComponent<PlayerKnight>();
    }    
    
    void Update() {
        if (Input.GetKeyDown(KeyBinds.BasicAttack) && enabled) {
            _knight.Attack();
        }

        //Debug.Log(PlayerStatsManager.Instance.speed);
    }
        
    void FixedUpdate() { 
        if (isShooting) rb.linearVelocity = Vector2.zero;
        else if (!_isKnockedBack) Walk();
    }
    
    private void Flip() {
        PlayerStatsManager.Instance.facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Walk() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0) {
            Flip();
        }
            
        anim.SetFloat(PlayerAnimatorData.Horizontal, Mathf.Abs(horizontal));
        anim.SetFloat(PlayerAnimatorData.Vertical, Mathf.Abs(vertical));
            
        rb.linearVelocity = new Vector2(horizontal, vertical).normalized * PlayerStatsManager.Instance.speed;
    }

    public void Knockback(Transform enemy, float force, float stunTime) {
        _isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine( KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        _isKnockedBack = false;
    }
}