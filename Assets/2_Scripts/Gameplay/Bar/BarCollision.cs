using UnityEngine;

public class BarCollision : MonoBehaviour
{
    private BoxCollider2D _collider;

    private BarMovement _movement;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();
        _movement = GetComponent<BarMovement>();
    }

    public void IgnoreCollisionsWithPlayer() {
        _collider.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            _movement.ChangeDirection();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            _movement.ChangeDirection();
        }
    }
}