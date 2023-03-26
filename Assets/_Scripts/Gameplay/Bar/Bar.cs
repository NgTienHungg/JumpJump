using UnityEngine;
using Sirenix.OdinInspector;

public enum BarType
{
    ShortBar,
    MediumBar,
    LongBar,
}

public class Bar : MonoBehaviour
{
    [ShowInInspector, ReadOnly]
    public BarType Type { get; private set; }

    private BarAsset _asset;
    private BarMovement _movement;
    private BarCollision _collision;
    private BarAnimation _animation;
    private BarPointHandler _pointHandler;

    private void Awake() {
        _asset = GetComponent<BarAsset>();
        _movement = GetComponent<BarMovement>();
        _collision = GetComponent<BarCollision>();
        _animation = GetComponent<BarAnimation>();
        _pointHandler = GetComponent<BarPointHandler>();
    }

    public void Setup(Vector3 position, BarType type, float speed, int direction) {
        Type = type;
        transform.position = position;
        _asset.SetSpriteByShape(type);
        _collision.SetColliderByShape(type);
        _movement.Setup(speed, direction);
    }

    public void Recall() {
        _collision.Reset();
        _animation.Reset();
        _pointHandler.Reset();
        PoolManager.Instance.Recall(gameObject);
    }
}