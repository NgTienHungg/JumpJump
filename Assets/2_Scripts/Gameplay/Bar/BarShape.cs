using UnityEngine;
using Sirenix.OdinInspector;

public enum BarShapeType
{
    ShortBar,
    MediumBar,
    LongBar,
}

public class BarShape : MonoBehaviour
{
    [ShowInInspector, ReadOnly] public BarShapeType Type { get; private set; }

    private BoxCollider2D _collider;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void SetShape(BarShapeType shapeType) {
        Type = shapeType;
        switch (Type) {
            case BarShapeType.ShortBar:
                SetShortBar();
                break;
            case BarShapeType.MediumBar:
                SetMediumBar();
                break;
            case BarShapeType.LongBar:
                SetLongBar();
                break;
        }
    }

    private void SetShortBar() {
        _collider.offset = new Vector2(0f, 0.1f);
        _collider.size = new Vector2(0.8f, 0.23f);
    }

    private void SetMediumBar() {
        _collider.offset = new Vector2(0f, 0.11f);
        _collider.size = new Vector2(1.03f, 0.2f);
    }

    private void SetLongBar() {
        _collider.offset = new Vector2(0f, 0.12f);
        _collider.size = new Vector2(1.3f, 0.21f);
    }
}