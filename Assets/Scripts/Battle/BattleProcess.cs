using UnityEngine;

public class BattleProcess : MonoBehaviour {
    private float _enemySpawnTimer;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    
    void Update() {
        _enemySpawnTimer -= Time.deltaTime;
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        if (_enemySpawnTimer <= 0) {
            foreach (Transform spawnPoint in spawnPoints) {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                _enemySpawnTimer = 3f;
            }
        }
    }
}