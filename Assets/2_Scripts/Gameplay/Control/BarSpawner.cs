using UnityEngine;
using System.Collections.Generic;

public class BarSpawner : MonoBehaviour
{
    [Header("List bars")]
    [SerializeField] private int _numberOfBars;
    [SerializeField] private float _firstBarPosY;
    [SerializeField] private float _distanceBetweenBars;
    private List<Bar> _listBar;

    [Header("Range spawn")]
    [SerializeField] private Range _positionRangeX;
    [SerializeField] private Range _speedRange;
    private Vector3 _lastBarPosition;
    private bool _spawnInRight;

    private void Start() {
        _listBar = new List<Bar> {
            CreateFirstBar()
        };
        RefreshListBar();
    }

    private void RefreshListBar() {
        while (_listBar.Count < _numberOfBars) {
            _listBar.Add(CreateBar());
        }
    }

    private Bar CreateFirstBar() {
        Bar firstBar = PoolManager.Instance.Spawn(Pool.Bar, transform).GetComponent<Bar>();
        firstBar.Setup(new Vector3(0f, _firstBarPosY), BarShapeType.MediumBar, 0f, 1);
        _lastBarPosition = firstBar.transform.position;
        _spawnInRight = Random.Range(0, 2) == 1;
        return firstBar;
    }

    private Bar CreateBar() {
        Bar newBar = PoolManager.Instance.Spawn(Pool.Bar, transform).GetComponent<Bar>();
        newBar.Setup(RandPos(), RandShape(), RandSpeed(), GetDir());
        _lastBarPosition = newBar.transform.position;
        _spawnInRight = !_spawnInRight;
        return newBar;
    }

    #region Spawn bar
    private Vector3 RandPos() {
        float posX = _spawnInRight ? Random.Range(_positionRangeX.min, _positionRangeX.max)
                                   : Random.Range(-_positionRangeX.max, -_positionRangeX.min);
        float posY = _lastBarPosition.y - _distanceBetweenBars;
        return new Vector3(posX, posY);
    }

    private BarShapeType RandShape() {
        int id = Random.Range(0, 3); // numberOfBarShape = 3;
        return (BarShapeType)id;
    }

    private float RandSpeed() {
        return _speedRange.Rand();
    }

    private int GetDir() {
        // spawn ben phai thi di ve ben trai, va nguoc lai
        return _spawnInRight ? -1 : 1;
    }
    #endregion
}

[System.Serializable]
public struct Range
{
    public float min, max;
    public float Rand() {
        return Random.Range(min, max);
    }
}