using UnityEngine;

public class SpawnManagerX : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int enemyCount;
    public int WaveCount { get; private set; } = 1;


    public GameObject player;

    private void Update() {
        enemyCount = FindObjectsOfType<EnemyX>().Length;

        if (enemyCount == 0) {
            SpawnEnemyWave(WaveCount);
        }
    }

    private Vector3 GenerateSpawnPosition() {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        var powerupSpawnOffset = new Vector3(0, 0, -15);

        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        WaveCount++;
        ResetPlayerPosition();
    }

    private void ResetPlayerPosition() {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
