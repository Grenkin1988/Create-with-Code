using UnityEngine;

public class MoveLeft : MonoBehaviour {
    [SerializeField]
    private float _moveSpeed = 10;

    private void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }
}
