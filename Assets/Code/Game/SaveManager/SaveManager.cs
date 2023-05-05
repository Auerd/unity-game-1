using UnityEngine;

public static class SaveManager
{
    public static void Save<T>(string key, T data)
    {
        string dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, dataString);
    }

    public static T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string dataString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(dataString);
        }
        return default;
    }

    public static bool TryLoad<T>(string key, out T data)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            data = JsonUtility.FromJson<T>(loadedString);
            if (data != null) return true;
        }
        data = default;
        return false;
    }
}
