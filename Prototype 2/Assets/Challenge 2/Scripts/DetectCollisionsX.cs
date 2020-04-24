using UnityEngine;

public class DetectCollisionsX : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
