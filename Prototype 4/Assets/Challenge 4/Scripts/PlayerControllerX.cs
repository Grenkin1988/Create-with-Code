using System.Collections;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10;
    private float powerupStrength = 25;

    [SerializeField]
    private ParticleSystem boostParticle;

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update() {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            TurboBoost();
        }
    }

    private void TurboBoost() {
        playerRb.AddForce(focalPoint.transform.forward * powerupStrength, ForceMode.Impulse);
        boostParticle.Play();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Powerup")) {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(nameof(PowerupCooldown));
        }
    }

    private IEnumerator PowerupCooldown() {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            var enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (hasPowerup) {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            } else {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }
    }
}
