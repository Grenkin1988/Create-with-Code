using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rigidbody;
    private bool isOnGround = true;
    private Animator _playerAnim;
    private AudioSource _playerAudio;

    [SerializeField]
    private float _jumpForce = 12;
    [SerializeField]
    private float _gravityModifier = 2;

    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private ParticleSystem dirtParticle;

    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip crashSound;

    public bool GameOver { get; private set; }

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    private void Start() {
        
        Physics.gravity *= _gravityModifier;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver) {
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            Debug.Log("Game Over!");
            explosionParticle.Play();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
