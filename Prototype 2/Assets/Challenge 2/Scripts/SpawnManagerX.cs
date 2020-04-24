using UnityEngine;

public class SpawnManagerX : MonoBehaviour {
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float spawnIntervalStart = 3.0f;
    private float spawnIntervalEnd = 5.0f;

    // Start is called before the first frame update
    private void Start() {
        Invoke(nameof(SpawnRandomBall), Random.Range(spawnIntervalStart, spawnIntervalEnd));
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall() {
        // Generate random ball index and random spawn position
        var spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        Invoke(nameof(SpawnRandomBall), Random.Range(spawnIntervalStart, spawnIntervalEnd));
    }
}
