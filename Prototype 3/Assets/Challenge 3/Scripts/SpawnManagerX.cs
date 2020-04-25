using UnityEngine;

public class SpawnManagerX : MonoBehaviour {
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    private void Start() {
        Invoke(nameof(SpawnObject), spawnDelay);
        playerControllerScript = FindObjectOfType<PlayerControllerX>();
    }

    // Spawn obstacles
    private void SpawnObject() {
        if (playerControllerScript.GameOver) { return; }
        // Set random spawn location and random object index
        var spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        Invoke(nameof(SpawnObject), spawnInterval);
    }
}
