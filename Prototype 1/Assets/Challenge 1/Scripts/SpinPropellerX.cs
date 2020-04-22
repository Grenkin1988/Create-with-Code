using UnityEngine;

public class SpinPropellerX : MonoBehaviour {
    [SerializeField]
    private float rotationSpeed;

    private void Update() => transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
}
