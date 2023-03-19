using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerControl : MonoBehaviour
{
    public static event Action OnPlayerJump;
    public static event Action OnPlayerLanding;
    public static event Action OnPlayerDeath;

    [SerializeField] private float _jumpForce;

    [ShowInInspector, ReadOnly] private bool _onGround;
    [ShowInInspector, ReadOnly] private bool _canJump;

    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!_onGround || !_canJump) {
            return;
        }
        if (Input.GetMouseButtonDown(0) && !Extensions.IsOverUI()) {
            Jump();
        }
    }

    private void Jump() {
        _onGround = false;
        _canJump = false;

        transform.parent = null;

        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y); // clear velo x
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        OnPlayerJump?.Invoke();
    }

    private void Landing(Transform barParent) {
        _onGround = true;
        this.Wait(250, () => _canJump = true); // wait camera follow

        transform.parent = barParent;

        OnPlayerLanding?.Invoke();
    }

    #region Check collision
    /// <summary>
    /// Player thoát khỏi Bar
    /// Bar.isTrigger = true để không không va chạm với Player
    /// Vẫn có hàm TriggerEnter để tiếp tục va chạm với Wall
    /// </summary>
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bar")) {
            var barCollision = collision.gameObject.GetComponent<BarCollision>();
            barCollision.IgnoreCollisionsWithPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bar")) {
            Landing(collision.gameObject.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("CheckLose")) {
            OnPlayerDeath?.Invoke();
        }
    }
    #endregion
}