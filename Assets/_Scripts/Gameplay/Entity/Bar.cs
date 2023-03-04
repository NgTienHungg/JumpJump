using UnityEngine;

public class Bar : MonoBehaviour
{
    private BoxCollider2D _collider;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void IgnoreCollisionsWithPlayer() {
        _collider.isTrigger = true;
    }
}