using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    async void FixedUpdate() {
        Vector2 newPosition = _rigidbody.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * WalkSpeed * Time.fixedDeltaTime;

        _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
        _spriteRenderer.flipY = Input.GetAxisRaw("Vertical") < 0;

        _rigidbody.MovePosition(newPosition);
    }
}
