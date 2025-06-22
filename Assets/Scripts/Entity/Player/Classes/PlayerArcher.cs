using UnityEngine;

public class PlayerArcher : MonoBehaviour {
    private Vector2 _aimDirection = Vector2.right;
    private float _shootTimer;
    public PlayerMovement playerMovement;
    public Transform launchPoint;
    public Animator anim;
    public GameObject arrowPrefab;
    
    void Update() {
        if (!enabled) return;
        
        _shootTimer -= Time.deltaTime;
        HandleAiming();
        SetShootingState();
    }

    private void OnEnable() {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 1);
    }
    
    private void OnDisable() {
        anim.SetLayerWeight(0, 1);
        anim.SetLayerWeight(1, 0);
    }

    private void SetShootingState() {
        if (Input.GetKeyDown(KeyBinds.BasicAttack) && _shootTimer <= 0) {
            playerMovement.isShooting = true;
            anim.SetBool($"IsShooting", true);
        }
    }
    
    private void HandleAiming() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f) {
            _aimDirection = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat(PlayerAnimatorData.AimX, _aimDirection.x);
            anim.SetFloat(PlayerAnimatorData.AimY, _aimDirection.y);
        }
    }

    public void Shoot() {
        if (!enabled) return;
        else if (_shootTimer > 0) return;
        
        Arrow arrow = Instantiate(arrowPrefab, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.direction = _aimDirection;
        _shootTimer = PlayerCooldown.Shoot;
        anim.SetBool(PlayerAnimatorData.IsShooting, false);
        
        playerMovement.isShooting = false;
    }

    public void ResetAnimations() {
        anim.SetBool(PlayerAnimatorData.IsShooting, false);
    }
}