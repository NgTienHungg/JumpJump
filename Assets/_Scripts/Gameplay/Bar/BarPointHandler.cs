using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class BarPointHandler : MonoBehaviour
{
    public static event Action OnGetPoint;
    public static event Action OnGetPerfect;

    [SerializeField] private float _rangePerfect;

    [ShowInInspector, ReadOnly] public bool HasNoPoint { get; set; }

    public void Reset() {
        HasNoPoint = false;
    }

    public void HandlePoint(Transform playerTrans) {
        if (HasNoPoint) return;

        float x = playerTrans.localPosition.x;
        Debug.LogWarning("x: " + x);
        if (x >= -_rangePerfect && x <= _rangePerfect) {
            OnGetPerfect?.Invoke();
        }
        else {
            OnGetPoint?.Invoke();
        }
    }
}