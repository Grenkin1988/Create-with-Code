using UnityEngine;

public class MoveLeft : MonoBehaviour {
    private PlayerController _playerController;
    
    [SerializeField]
    private float _moveSpeed = 10;
    [SerializeField]
    private float _leftBound = -15;

    private void Awake() {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if (!_playerController.GameOver) {
            transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
        }
        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
