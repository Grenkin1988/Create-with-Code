using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    private float topBound = 30;
    private float lowerBound = -10;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {
        if (transform.position.z > topBound) {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        } else if (transform.position.z < lowerBound) {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }

    }
}
