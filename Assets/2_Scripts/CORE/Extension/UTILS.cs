using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public static class UTILS
{
    /// <summary>
    /// kiểm tra xem chuột có đang nằm trên UI hay không?
    /// UI có tick chọn RaycastTarget
    /// </summary>
    public static bool IsPointerOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    /// <summary>
    /// Lấy toạ độ chuột trong đơn vị World (not pixel)
    /// </summary>
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePoint); // z = -10
        return new Vector3(mousePos.x, mousePos.y);
    }

    public static bool InRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }

    public static int RandomRange(int max, int min)
    {
        return Random.Range(min, max + 1);
    }

    //[MenuItem("Utils/Clear PlayerPrefs")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}