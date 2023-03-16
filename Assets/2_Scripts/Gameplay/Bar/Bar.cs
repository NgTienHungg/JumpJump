using UnityEngine;

public class Bar : MonoBehaviour
{
    private BarShape _shape;
    private BarAsset _asset;
    private BarMovement _movement;

    private void Awake() {
        _shape = GetComponent<BarShape>();
        _asset = GetComponent<BarAsset>();
        _movement = GetComponent<BarMovement>();
    }

    public void Setup(Vector3 position, BarShapeType shapeType, float speed, int direction) {
        transform.position = position;
        _shape.SetShape(shapeType);
        _asset.SetSpriteByShape();
        _movement.Setup(speed, direction);
    }
}