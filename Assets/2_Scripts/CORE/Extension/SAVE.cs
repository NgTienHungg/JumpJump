using UnityEngine;

public static class SAVE
{
    #region KEY
    #endregion

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static float GetFloat(string key, float value)
    {
        return PlayerPrefs.GetFloat(key, value);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
}