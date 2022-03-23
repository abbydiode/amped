using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        Vector2 movementDirection = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), 1);
        Vector2 newPosition = _rigidbody.position + movementDirection  * WalkSpeed * Time.fixedDeltaTime;

        _rigidbody.MovePosition(newPosition);

        _animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        _animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        _animator.SetFloat("Velocity", movementDirection.magnitude);
    }
}
