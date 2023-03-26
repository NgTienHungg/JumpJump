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

    private Transform _playerTrans;

    #region Event
    private void Awake() {
        PlayerControl.OnPlayerLanding += RefreshListBar;
    }

    private void OnDestroy() {
        PlayerControl.OnPlayerLanding -= RefreshListBar;
    }
    #endregion

    private void Start() {
        _playerTrans = FindObjectOfType<Player>().transform;
        _listBar = new List<Bar> {
            CreateFirstBar()
        };
        RefreshListBar();
    }

    private void RefreshListBar() {
        // disappear Bars above Player
        while (_listBar.Count != 0 && _listBar[0].transform.position.y > _playerTrans.position.y) {
            _listBar[0].GetComponent<BarAnimation>().Disappear(true);
            _listBar.RemoveAt(0);
            Debug.Log("Remove bar");
        }

        // fill list
        while (_listBar.Count < _numberOfBars) {
            Debug.Log("Add bar in list");
            _listBar.Add(CreateBar());
        }
    }

    private Bar CreateFirstBar() {
        Bar firstBar = PoolManager.Instance.Spawn(Pool.Bar, transform).GetComponent<Bar>();
        firstBar.Setup(new Vector3(0f, _firstBarPosY), BarType.MediumBar, 0f, 1);
        firstBar.GetComponent<BarPointHandler>().HasNoPoint = true;
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

    private BarType RandShape() {
        int id = Random.Range(0, 3); // numberOfBarShape = 3;
        return (BarType)id;
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