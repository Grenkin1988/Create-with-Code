using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float _speed = 20;
    [SerializeField]
    private float _turnSpeed = 10;
    private float _forwardInput = 20;
    private float _horizontalInput;

    private void Update() {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}
