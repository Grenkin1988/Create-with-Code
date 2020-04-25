using UnityEngine;

public class Target : MonoBehaviour {
    private Rigidbody targetRb;

    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 16;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float xRange = 4;
    [SerializeField] private float ySpawnPos = -6;

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
    }

    private void Update() {

    }

    private void OnMouseDown() {
        DestroyThis();
    }

    private void DestroyThis() { 
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        DestroyThis();
    }

    private Vector3 RandomForce() =>
        Vector3.up * Random.Range(minSpeed, maxSpeed);

    private float RandomTorque() =>
        Random.Range(-maxTorque, maxTorque);

    private Vector3 RandomSpawnPos() =>
        new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
}
