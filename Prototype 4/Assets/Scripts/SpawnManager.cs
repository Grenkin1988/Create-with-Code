using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRange = 9;

    private void Start() {
        SpawnEnemy();
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

    }
}
