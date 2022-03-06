using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    public float JumpHeight = 10;
    [Range(0, 1)] public float AirControlMultiplier = 0.5f;

    void FixedUpdate() {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * WalkSpeed, 0, 0) * Time.fixedDeltaTime;

        if (Input.GetButton("Jump")) {
            transform.position += new Vector3(0, JumpHeight, 0) * Time.fixedDeltaTime;
        }
    }
}
