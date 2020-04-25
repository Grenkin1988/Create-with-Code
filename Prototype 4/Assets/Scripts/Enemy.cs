using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody enemyRigidbody;
    private PlayerController player;

    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float destronBelowY = -10;

    private void Awake() {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if(transform.position.y < destronBelowY) {
            Destroy(gameObject);
        }
        var lookDirection = player.transform.position - transform.position;
        enemyRigidbody.AddForce(lookDirection.normalized * moveSpeed);
    }
}
