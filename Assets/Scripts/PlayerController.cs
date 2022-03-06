using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    public float JumpForce = 100;
    public Transform FeetPosition;
    [Range(0, 1)] public float AirControlMultiplier = 0.5f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool isGrounded = false;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate() {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * WalkSpeed, 0, 0) * Time.fixedDeltaTime;
        _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;

        if (Input.GetButton("Jump")) {
            _rigidbody.AddForce((Vector2.up * JumpForce) * Time.fixedDeltaTime);
        }

        Debug.Log(Physics2D.Raycast(FeetPosition.position, Vector2.down, 0.1f, LayerMask.GetMask()).collider.name);
    }
}
