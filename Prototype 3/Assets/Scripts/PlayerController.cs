using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rigidbody;
    private bool isOnGround = true;
    

    [SerializeField]
    private float _jumpForce = 12;
    [SerializeField]
    private float _gravityModifier = 2;

    public bool GameOver { get; private set; }

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
