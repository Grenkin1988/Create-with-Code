using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public bool GameOver { get; private set; }

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip floorSound;

    [SerializeField]
    private float hightLimit;
    private bool IsLowEnough => transform.position.y < hightLimit;

    private void Awake() {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void Start() {
        Physics.gravity *= gravityModifier;
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    private void Update() {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !GameOver && IsLowEnough) {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bomb")) {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            GameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject, 10);
        } else if (other.gameObject.CompareTag("Money") && !GameOver) {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Ground") && !GameOver) {
            playerAudio.PlayOneShot(floorSound, 1.0f);
            playerRb.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }
    }
}
