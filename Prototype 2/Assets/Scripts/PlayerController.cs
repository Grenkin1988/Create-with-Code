using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    [SerializeField]
    private float _movementSpeed = 10.0f;
    [SerializeField]
    private float _xBorderValue = 10;

    private void Update()
    {
        var current = transform.position;
        if(current.x < -_xBorderValue) {
            transform.position = new Vector3(-_xBorderValue, current.y, current.z);
        }
        if (current.x > _xBorderValue) {
            transform.position = new Vector3(_xBorderValue, current.y, current.z);
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _horizontalInput * _movementSpeed);
    }
}
