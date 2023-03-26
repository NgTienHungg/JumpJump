using Sirenix.OdinInspector;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [ShowInInspector, ReadOnly] public int Score { get; private set; }

    [ShowInInspector, ReadOnly] public int ComboPerfect { get; private set; }

    public int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        private set => PlayerPrefs.SetInt("HighScore", value);
    }

    private void Awake() {
        Instance = this;
        Reset();

        BarPointHandler.OnGetPoint += GetScore;
        BarPointHandler.OnGetPerfect += Perfect;
    }

    private void OnDestroy() {
        BarPointHandler.OnGetPoint += GetScore;
        BarPointHandler.OnGetPerfect += Perfect;
    }

    private void Reset() {
        Score = 0;
        ComboPerfect = 0;
    }

    private void GetScore() {
        Debug.Log("Add score");
        ComboPerfect = 0;
        Score++;
    }

    private void Perfect() {
        ComboPerfect++;
        Debug.Log("Perfect: " + ComboPerfect);
        Score += (ComboPerfect + 1);
    }
}