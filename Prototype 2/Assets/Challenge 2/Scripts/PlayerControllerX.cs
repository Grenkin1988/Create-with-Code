using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public GameObject dogPrefab;
    private float lastCalledAtTime;
    [SerializeField]
    private float minimumDelay = 3;

    // Update is called once per frame
    private void Update() {
        float currentTime = Time.time;
        if (currentTime - lastCalledAtTime > minimumDelay && Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastCalledAtTime = currentTime;
        }
    }
}
