using UnityEngine;
using Sirenix.OdinInspector;

public class BarMovement : MonoBehaviour
{
    [ShowInInspector, ReadOnly] private float _speed;

    private int _direction;

    public void Setup(float speed, int direction) {
        _speed = speed;
        _direction = direction;
    }

    private void Update() {
        transform.Translate(_direction * _speed * Time.deltaTime * Vector3.right);
    }

    public void ChangeDirection() {
        _direction *= -1;
    }
}