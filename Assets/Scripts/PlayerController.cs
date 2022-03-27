using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Localization;

public class PlayerController : MonoBehaviour {
    public float WalkSpeed = 5;
    public Text score;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Vector2 movementDirection;
    private GameObject currentScrap;
    private LocalizedStringTable

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

    void OnInteract(InputValue input) {
        if (currentScrap != null) {
            Destroy(currentScrap);
            currentScrap = null;
            score.text = (int.Parse(score.text) + 1).ToString();

            if (int.Parse(score.text) == 5) {
                score.text = "You win!";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Scrap") {
            currentScrap = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Scrap" && collider.gameObject == currentScrap) {
            currentScrap = null;
        }
    }
}
