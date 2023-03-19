using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;

public class CameraFollowPlayer : MonoBehaviour
{
    [ShowInInspector, ReadOnly] private bool _isFollowing;

    private Player _player;

    private float _distanceWithPlayer;

    #region Event
    private void Awake() {
        PlayerControl.OnPlayerLanding += Follow;
        PlayerControl.OnPlayerJump += UnFollow;
        PlayerControl.OnPlayerDeath += UnFollow;
    }

    private void OnDestroy() {
        PlayerControl.OnPlayerLanding -= Follow;
        PlayerControl.OnPlayerJump -= UnFollow;
        PlayerControl.OnPlayerDeath -= UnFollow;
    }
    #endregion

    private void Follow() {
        if (_player == null) {
            _player = FindObjectOfType<Player>();
            _distanceWithPlayer = _player.transform.position.y - transform.position.y;
        }

        //transform.DOKill();
        transform.DOMoveY(_player.transform.position.y - _distanceWithPlayer, 0.5f)
                 .SetEase(Ease.OutCubic)
                 .OnComplete(() => _isFollowing = true);
    }

    private void UnFollow() {
        transform.DOKill();
        _isFollowing = false;
    }

    //private void LateUpdate() {
    //    if (_isFollowing) {
    //        transform.DOMoveY(_player.transform.position.y - _distanceWithPlayer, Time.deltaTime)
    //                 .SetEase(Ease.OutCubic);
    //    }
    //}
}