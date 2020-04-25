using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float _horsePower = 20;
    [SerializeField]
    private float _turnSpeed = 10;

    [SerializeField]
    private Transform centerOfMass;

    private float _forwardInput;
    private float _horizontalInput;

    private Rigidbody playerRigidbody;

    [SerializeField]
    private TextMeshProUGUI speedometerText;
    private float speed;

    [SerializeField]
    private TextMeshProUGUI rpmText;
    private float rpm;

    [SerializeField]
    private List<WheelCollider> allWheels;
    private int wheelsOnGround;

    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.centerOfMass = centerOfMass.position;
    }

    private void Update() {
        if (IsOnGround()) {
            _horizontalInput = Input.GetAxis("Horizontal");
            _forwardInput = Input.GetAxis("Vertical");

            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
        }
        speed = Mathf.Round(playerRigidbody.velocity.magnitude * 2.237f);
        speedometerText.text = $"Speed: {speed}mph";

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.text = $"RPM: {rpm}";
    }

    private void FixedUpdate() {
        if (IsOnGround()) {
            playerRigidbody.AddRelativeForce(Vector3.forward * _horsePower * _forwardInput);
        }
    }

    private bool IsOnGround() {
        wheelsOnGround = 0;
        foreach (var wheel in allWheels) {
            if (wheel.isGrounded) {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround >= 2;
    }
}
