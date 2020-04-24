using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    [SerializeField]
    private float _topBound = 30;
    [SerializeField]
    private float _lowerBound = -10;

    private void Update() {
        if (transform.position.z > _topBound) {
            Destroy(gameObject);
        } else if(transform.position.z < _lowerBound) {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
