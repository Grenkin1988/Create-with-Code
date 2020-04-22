using UnityEngine;

public class FollowPlayerX : MonoBehaviour {
    [SerializeField]
    private Transform plane;
    private Vector3 offset = new Vector3(30, 0, 10);

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() => transform.position = plane.position + offset;
}
