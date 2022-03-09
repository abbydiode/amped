using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float RollSpeed = 2.5f;
    private Transform player;
    private Rigidbody2D _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate() {
        _rigidbody.AddForce((player.position - transform.position).normalized * RollSpeed);
    }
}
