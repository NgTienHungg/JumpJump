using UnityEngine;

public class BarAsset : MonoBehaviour
{
    [SerializeField] private Sprite _shortSprite;
    [SerializeField] private Sprite _mediumSprite;
    [SerializeField] private Sprite _longSprite;

    private SpriteRenderer _renderer;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpriteByShape(BarType type) {
        switch (type) {
            case BarType.ShortBar:
                _renderer.sprite = _shortSprite;
                break;
            case BarType.MediumBar:
                _renderer.sprite = _mediumSprite;
                break;
            case BarType.LongBar:
                _renderer.sprite = _longSprite;
                break;
        }
    }
}