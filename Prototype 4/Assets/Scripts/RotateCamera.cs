using UnityEngine;

public class RotateCamera : MonoBehaviour {
    [SerializeField]
    private float rotationSpeed;

    private void Start() {

    }

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * rotationSpeed);
    }
}
