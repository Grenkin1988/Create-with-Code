using UnityEngine;

public class SpawnManager : MonoBehaviour {
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    [SerializeField]
    private GameObject _obstaclePrefab;
    [SerializeField]
    private float _startDelay = 2;
    [SerializeField]
    private float _repeateRate = 2;

    private PlayerController _playerController;

    private void Awake() {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Start() {
        Invoke(nameof(SpawnObstacle), _startDelay);
    }

    private void SpawnObstacle() {
        if(_playerController.GameOver) { return; }
        Instantiate(_obstaclePrefab, spawnPos, _obstaclePrefab.transform.rotation);
        Invoke(nameof(SpawnObstacle), _repeateRate);
    }
}
