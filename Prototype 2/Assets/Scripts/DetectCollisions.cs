using UnityEngine;

public class DetectCollisions : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
