using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; }

    public int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        set => PlayerPrefs.SetInt("HighScore", value);
    }

    private void Awake() {
        Instance = this;
        Score = 0;

        PlayerControl.OnPlayerLanding += AddScore;
    }

    private void OnDestroy() {
        PlayerControl.OnPlayerLanding -= AddScore;
    }

    private void AddScore() {
        Score++;
    }
}