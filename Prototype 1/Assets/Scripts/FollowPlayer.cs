using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Vector3 _offset = new Vector3(0, 7, -12);

    private void Update() => transform.position = _player.position + _offset;
}
