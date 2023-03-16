using System;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action OnGameOver;

    #region Register listen event
    private void Awake() {
        PlayerControl.OnPlayerDeath += GameOver;
    }

    private void OnDestroy() {
        PlayerControl.OnPlayerDeath -= GameOver;
    }
    #endregion

    private void Start() {
        OnStartGame?.Invoke();
    }

    private void GameOver() {
        OnGameOver?.Invoke();
    }
}