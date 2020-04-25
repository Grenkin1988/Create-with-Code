using UnityEngine;

public class EnemyX : MonoBehaviour {
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX spawnManager;

    private void Start() {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawnManager = FindObjectOfType<SpawnManagerX>();
        speed *= spawnManager.WaveCount;
    }

    private void Update() {
        var lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Enemy Goal") {
            Destroy(gameObject);
        } else if (other.gameObject.name == "Player Goal") {
            Destroy(gameObject);
        }
    }
}
