using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blink : MonoBehaviour {
    private float _blinkTimer;
    private sbyte _blinkTimerCounter;
    public Transform player;
    public Image blinkImage;
    public TMP_Text blinkTimerText;

    void Update() {
        _blinkTimer -= Time.deltaTime;
        CastBlink();
        UpdateBlinkIcon();
        UpdateBlinkTimerText();
    }

    private bool ManagePlayerPos() {
        if (player.transform.position.x <= 0.96 ||
            player.transform.position.x >= 51 ||
            player.transform.position.y >= -12.60 ||
            player.transform.position.y <= -45) {
            player.transform.position = new Vector2(25f, -31.65f);
            return true;
        } 
        return false;
    }
    
    private void CastBlink() {
        float blinkDistance = PlayerStatsManager.Instance.facingDirection * PlayerStatsManager.Instance.blinkDistance;
        if (Input.GetKeyDown(KeyBinds.Blink) && _blinkTimer <= 0) {
            if (ManagePlayerPos())  _blinkTimer = PlayerCooldown.Blink * 2;
            else {
                player.transform.position = new Vector2(player.transform.position.x + blinkDistance, player.transform.position.y);
                _blinkTimer = PlayerCooldown.Blink;
            }
        }
    }

    private void UpdateBlinkIcon() {
        if (_blinkTimer <= 0) blinkImage.color = Color.white;
        else blinkImage.color = new(1f, 1f, 1f, 0.5f);
    }

    private void UpdateBlinkTimerText() {
        _blinkTimerCounter = (sbyte)_blinkTimer;
        if (_blinkTimer <= 0) {
            blinkTimerText.enabled = false;
            _blinkTimerCounter = 0;
        }
        else {
            blinkTimerText.enabled = true;
            blinkTimerText.text = $"{_blinkTimerCounter + 1}";
        }
    }
}