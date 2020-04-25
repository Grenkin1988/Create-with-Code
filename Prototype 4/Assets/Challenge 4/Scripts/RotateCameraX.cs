using UnityEngine;

public class RotateCameraX : MonoBehaviour {
    private float speed = 200;
    public GameObject player;

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position;
    }
}
