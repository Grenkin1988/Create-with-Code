using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRange = 9;

    [SerializeField]
    private GameObject powerupPrefab;

    private int enemyCount;
    private int waveNumber = 1;

    private void Start() {
        SpawnEnemyWave(waveNumber);
    }

    private void SpawnEnemyWave(int numberOfEnemies) {
        for (int i = 0; i < numberOfEnemies; i++) {
            SpawnEnemy();
        }
        SpawnPowerUp();
    }

    private void SpawnPowerUp() {
        var spawnPos = GenerateSpawnPosition();
        Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
    }

    private void SpawnEnemy() {
        var spawnPos = GenerateSpawnPosition();
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        var spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }

    private void Update() {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
}
