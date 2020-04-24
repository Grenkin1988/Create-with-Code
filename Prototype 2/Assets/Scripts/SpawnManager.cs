using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] _animalPrefabs;
    [SerializeField]
    private float _spawnPositionZ = 20;
    [SerializeField]
    private float _spawnPositionXRange = 20;

    [SerializeField]
    private float _spawnDelay = 2;
    [SerializeField]
    private float _spawnInterval = 1.5f;

    private void Start() {
        InvokeRepeating(nameof(SpawnRandomAnimal), _spawnDelay, _spawnInterval);
    }

    private void Update() {
    }

    private void SpawnRandomAnimal() {
        int index = Random.Range(0, _animalPrefabs.Length);
        var prefab = _animalPrefabs[index];

        var spawnPosition = new Vector3(Random.Range(-_spawnPositionXRange, _spawnPositionXRange), 0, _spawnPositionZ);

        Instantiate(prefab, spawnPosition, prefab.transform.rotation);
    }
}
