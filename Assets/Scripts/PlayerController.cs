using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    public float JumpForce = 3;
    public Transform FeetPosition;
    [Range(0, 1)] public float AirControlMultiplier = 0.75f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool isGrounded = false;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate() {
        Vector2 newVelocity = _rigidbody.velocity;

        _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;

        isGrounded = Physics2D.Raycast(FeetPosition.position, Physics.gravity.normalized, 0.1f, ~LayerMask.GetMask("Player")).collider != null;

        if (Input.GetButton("Jump") && isGrounded) {
            newVelocity.y += JumpForce;
        }

        newVelocity.x = Input.GetAxis("Horizontal") * WalkSpeed * (isGrounded ? 1 : AirControlMultiplier);
        
        _rigidbody.velocity = newVelocity;
    }
}
