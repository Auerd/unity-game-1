using UnityEngine;
using Newtonsoft.Json;

public static class SaveManager
{
	private static readonly JsonSerializerSettings settings = new()
	{
		ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
	};

	public static void Save<T>(string key, T data) where T : new()
    {
		string jsonDataString = JsonConvert.SerializeObject(data, settings);
		PlayerPrefs.SetString(key, jsonDataString);
	}

    public static T Load<T>(string key) where T : new()
    {
		if (PlayerPrefs.HasKey(key))
		{
			string loadedString = PlayerPrefs.GetString(key);
			return JsonConvert.DeserializeObject<T>(loadedString, settings);
		}
		return new T();
	}

	public static bool TryLoad<T>(string key, out T data) where T : new()
	{
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            data = JsonConvert.DeserializeObject<T>(loadedString, settings);
			return true;
        }
		data = new T();
		return false;
    }
}
