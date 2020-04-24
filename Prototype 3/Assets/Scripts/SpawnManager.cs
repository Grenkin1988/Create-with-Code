using UnityEngine;

public class SpawnManager : MonoBehaviour {
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    [SerializeField]
    private GameObject _obstaclePrefab;
    [SerializeField]
    private float _startDelay = 2;
    [SerializeField]
    private float _repeateRate = 2;

    private void Start() {
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeateRate);
    }

    // Update is called once per frame
    private void SpawnObstacle() {
        Instantiate(_obstaclePrefab, spawnPos, _obstaclePrefab.transform.rotation);
    }
}
