using UnityEngine;

public class MoveForwardX : MonoBehaviour {
    public float speed;

    // Update is called once per frame
    private void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
