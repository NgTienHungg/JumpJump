using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;

    private void Awake() {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _textMesh.text = "0";
    }

    private void FixedUpdate() {
        _textMesh.text = ScoreManager.Instance.Score.ToString();
    }
}