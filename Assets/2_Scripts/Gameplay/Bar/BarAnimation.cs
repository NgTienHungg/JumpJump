using DG.Tweening;
using UnityEngine;

public class BarAnimation : MonoBehaviour
{
    private Bar _bar;

    private SpriteRenderer _renderer;

    private void Awake() {
        _bar = GetComponent<Bar>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Reset() {
        _renderer.DOKill();
        _renderer.Fade(1f);
    }

    public void Disappear(bool recall = default) {
        _renderer.DOFade(0f, 0.5f).OnComplete(() => {
            if (recall) {
                _bar.Recall();
            }
        });
    }
}