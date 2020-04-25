using UnityEngine;

public class DetectCollisions : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // Instead of destroying the projectile when it collides with an animal
        //Destroy(other.gameObject); 

        // Just deactivate the food and destroy the animal
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
