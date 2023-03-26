using UnityEngine;

public class CameraResize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rink;

    private void Awake() {

        #region VERTICAL FIT
        //Camera.main.orthographicSize = _screenBound.bounds.size.x * Screen.height / Screen.width * 0.5f;
        #endregion

        #region HORIZONTAL FIT
        //Camera.main.orthographicSize = _screenBound.bounds.size.y / 2;
        #endregion

        #region ENTIRE FIT
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = _rink.bounds.size.x / _rink.bounds.size.y;

        if (screenRatio >= targetRatio) {
            Camera.main.orthographicSize = _rink.bounds.size.y / 2;
        }
        else {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = _rink.bounds.size.y / 2 * differenceInSize;
        }
        #endregion
    }
}

#region Tutorial & Source
// https://youtu.be/3xXlnSetHPM
// https://pressstart.vip/tutorials/2018/06/14/37/understanding-orthographic-size.html
#endregion