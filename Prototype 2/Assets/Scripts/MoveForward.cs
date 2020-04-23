using UnityEngine;

public class MoveForward : MonoBehaviour {
    [SerializeField]
    private float _speed = 40;

    private void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
