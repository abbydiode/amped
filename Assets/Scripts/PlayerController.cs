using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Vector2 movementDirection;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        Vector2 newPosition = _rigidbody.position + movementDirection  * WalkSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(newPosition);
    }

    void OnMove(InputValue input) {
        movementDirection = input.Get<Vector2>();

        _animator.SetFloat("Horizontal", movementDirection.x);
        _animator.SetFloat("Vertical", movementDirection.y);
        _animator.SetFloat("Velocity", movementDirection.magnitude);
    }
}
