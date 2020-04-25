using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;

    [SerializeField]
    private float moveSpped = 10;

    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update() {
        float forward = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * moveSpped * forward);
    }
}
