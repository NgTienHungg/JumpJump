using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI textTMP;

    private void Awake() {
        this.textTMP = GetComponent<TextMeshProUGUI>();
        this.textTMP.text = "0";
    }

    private void FixedUpdate() {
        this.textTMP.text = ScoreManager.Instance.Score.ToString();
    }
}