using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5f;
    public float JumpHeight = 10f;

    void FixedUpdate() {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * WalkSpeed, 0, 0) * Time.fixedDeltaTime;

        if (Input.GetButton("Jump")) {
            transform.position += new Vector3(0, JumpHeight, 0) * Time.fixedDeltaTime;
        }
    }
}
