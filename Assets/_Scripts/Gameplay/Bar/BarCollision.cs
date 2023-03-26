using UnityEngine;

public class BarCollision : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private BoxCollider2D shortCollider;
    [SerializeField] private BoxCollider2D mediumCollider;
    [SerializeField] private BoxCollider2D longCollider;

    private BoxCollider2D _collider;

    private BarMovement _movement;
    private BarPointHandler _pointHandler;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();
        _movement = GetComponent<BarMovement>();
        _pointHandler = GetComponent<BarPointHandler>();
    }

    public void Reset() {
        _collider.isTrigger = false;
    }

    public void SetColliderByShape(BarType type) {
        var collider = type switch {
            BarType.ShortBar => shortCollider,
            BarType.MediumBar => mediumCollider,
            BarType.LongBar => longCollider,
            _ => null,
        };

        _collider.size = collider.size;
        _collider.offset = collider.offset;
    }

    public void IgnoreCollisionsWithPlayer() {
        _collider.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            _movement.ChangeDirection();
        }
        else if (collision.gameObject.CompareTag("Player")) {
            _pointHandler.HandlePoint(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            _movement.ChangeDirection();
        }
    }
}