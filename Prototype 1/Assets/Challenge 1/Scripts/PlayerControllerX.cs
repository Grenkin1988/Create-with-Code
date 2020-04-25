using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private float verticalInput;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void FixedUpdate() {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime * verticalInput);
    }
}
