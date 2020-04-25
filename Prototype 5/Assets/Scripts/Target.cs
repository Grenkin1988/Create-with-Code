using UnityEngine;

public class Target : MonoBehaviour {
    private Rigidbody targetRb;
    private GameManager gameManager;

    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 16;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float xRange = 4;
    [SerializeField] private float ySpawnPos = -6;

    [SerializeField]
    private int pointValue = 10;

    [SerializeField]
    private ParticleSystem explosionParticle;

    private void Awake() {
        targetRb = GetComponent<Rigidbody>();
    }

    private void Start() {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(
            RandomTorque(),
            RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update() {

    }

    private void OnMouseDown() {
        if (!gameManager.IsGameActive) { return; }
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    private Vector3 RandomForce() =>
        Vector3.up * Random.Range(minSpeed, maxSpeed);

    private float RandomTorque() =>
        Random.Range(-maxTorque, maxTorque);

    private Vector3 RandomSpawnPos() =>
        new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
}
