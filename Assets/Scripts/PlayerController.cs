using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5f;
    Transform transform;
    void Start() {
        transform = GetComponent<Transform>();
    }

    void FixedUpdate() {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * WalkSpeed, 0, 0) * Time.deltaTime;
    }
}
