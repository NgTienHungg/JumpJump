using UnityEngine;

public class BarAsset : MonoBehaviour
{
    [SerializeField] private Sprite _shortSprite;
    [SerializeField] private Sprite _mediumSprite;
    [SerializeField] private Sprite _longSprite;

    private SpriteRenderer _renderer;

    private BarShape _shape;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
        _shape = GetComponent<BarShape>();
    }

    public void SetSpriteByShape() {
        switch (_shape.Type) {
            case BarShapeType.ShortBar:
                _renderer.sprite = _shortSprite;
                break;
            case BarShapeType.MediumBar:
                _renderer.sprite = _mediumSprite;
                break;
            case BarShapeType.LongBar:
                _renderer.sprite = _longSprite;
                break;
        }
    }
}