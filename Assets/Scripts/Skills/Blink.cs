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
    
    private void CastBlink() {
        float blinkDistance = PlayerStatsManager.Instance.facingDirection * PlayerStatsManager.Instance.blinkDistance;
        if (Input.GetKeyDown(KeyBinds.Blink) && _blinkTimer <= 0) {
            player.transform.position = new Vector2(player.transform.position.x + blinkDistance, player.transform.position.y);
            _blinkTimer = PlayerCooldown.Blink;
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