using UnityEngine;

public class Bar : MonoBehaviour
{
    private BarShape _shape;
    private BarAsset _asset;
    private BarMovement _movement;
    private BarCollision _collision;
    private BarAnimation _animation;

    private void Awake() {
        _shape = GetComponent<BarShape>();
        _asset = GetComponent<BarAsset>();
        _movement = GetComponent<BarMovement>();
        _animation = GetComponent<BarAnimation>();
    }

    public void Setup(Vector3 position, BarShapeType shapeType, float speed, int direction) {
        transform.position = position;
        _shape.SetShape(shapeType);
        _asset.SetSpriteByShape();
        _movement.Setup(speed, direction);
    }

    public void Recall() {
        _collision.Reset();
        _animation.Reset();
        PoolManager.Instance.Recall(gameObject);
    }
}