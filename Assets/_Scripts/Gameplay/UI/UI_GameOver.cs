using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    private void Awake() {
        Observer.GameOver += Enable;
    }

    private void OnDestroy() {
        Observer.GameOver -= Enable;
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