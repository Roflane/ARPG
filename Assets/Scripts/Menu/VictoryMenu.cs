using UnityEngine;
using TMPro;

public class VictoryMenu : MonoBehaviour {
    public TMP_Text killedCountText;

    void Update() {
        DrawKilledCount();
    }

    private void DrawKilledCount() {
        killedCountText.text = $"Kills: {PlayerStatsManager.Instance.killedCount}";
    }
}