using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _jumpForce;

    [ShowInInspector, ReadOnly] private bool _onGround;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        _onGround = false;
    }

    private void Update() {
        if (!_onGround) {
            return;
        }
        if (Input.GetMouseButtonDown(0) && !Extensions.IsOverUI()) {
            Jump();
        }
    }

    private void Jump() {
        Debug.Log("Player: jump");
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _onGround = false;
    }

    private void Grounding() {
        Debug.Log("Player: on ground");
        _onGround = true;
    }

    /// <summary>
    /// Player thoát khỏi Bar
    /// Bar.isTrigger = true để không không va chạm với Player
    /// </summary>
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bar")) {
            collision.gameObject.GetComponent<Bar>().IgnoreCollisionsWithPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bar")) {
            Grounding();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("CheckLose")) {
            Observer.GameOver?.Invoke();
        }
    }
}