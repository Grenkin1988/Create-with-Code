using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;

    [SerializeField]
    private GameObject powerupIndicator;

    [SerializeField]
    private float moveSpped = 10;
    private bool hasPowerup;
    [SerializeField]
    private float powerUpStrength = 15;
    [SerializeField]
    private float powerUpDuration = 7;

    [SerializeField]
    private float gameOverBelowY = -10;

    public bool IsGameOver { get; private set; }

    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update() {
        if (IsGameOver) { return; }
        float forward = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * moveSpped * forward);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < gameOverBelowY) {
            IsGameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Powerup")) {
            hasPowerup = true;
            powerupIndicator.SetActive(hasPowerup);
            Destroy(other.gameObject);
            StartCoroutine(nameof(PowerupCountdownRoutine));
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (hasPowerup && collision.gameObject.CompareTag("Enemy")) {
            var enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(hasPowerup);
    }
}
