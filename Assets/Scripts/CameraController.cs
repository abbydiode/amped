using UnityEngine;

public class CameraController : MonoBehaviour {
    public float VerticalOffset = 2;
    [Range(0, 0.5f)] public float SmoothingTime = 0.1f;
    private Transform player;
    [SerializeField] private Vector3 velocity = Vector3.zero;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate() {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y + VerticalOffset, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, SmoothingTime, Mathf.Infinity, Time.fixedDeltaTime);
    }
}
