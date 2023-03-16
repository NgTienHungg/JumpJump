using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class UI_GameOver : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1f;

        GameControl.OnGameOver += Enable;
    }

    private void OnDestroy() {
        GameControl.OnGameOver -= Enable;
    }

    private void Start() => Disable();

    private void Enable() {
        gameObject.SetActive(true);
    }

    private void Disable() {
        gameObject.SetActive(false);
    }

    public void OnReplayButton() {
        SceneManager.LoadScene(0);
    }
}