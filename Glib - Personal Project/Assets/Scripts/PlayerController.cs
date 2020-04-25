using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float xBound = 12;
    [SerializeField]
    private float zBound = 5;

    private void Start() {

    }

    private void Update() {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    private void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontal);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * vertical);
    }

    private void ConstrainPlayerPosition() {
        var position = transform.position;
        float xPos = Mathf.Clamp(position.x, -xBound, xBound);
        float zPos = Mathf.Clamp(position.z, -zBound, zBound);
        transform.position = new Vector3(xPos, position.y, zPos);
    }
}
