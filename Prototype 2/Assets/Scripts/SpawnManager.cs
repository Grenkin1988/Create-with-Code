using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] _animalPrefabs;
    [SerializeField]
    private float _spawnPositionZ = 20;
    [SerializeField]
    private float _spawnPositionXRange = 20;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S) && _animalPrefabs?.Length > 0) {

            int index = Random.Range(0, _animalPrefabs.Length);
            var prefab = _animalPrefabs[index];

            var spawnPosition = new Vector3(Random.Range(-_spawnPositionXRange, _spawnPositionXRange), 0, _spawnPositionZ);

            Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        }
    }
}
