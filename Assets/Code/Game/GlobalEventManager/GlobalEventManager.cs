using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GlobalEventManager")]
public class GlobalEventManager : ScriptableObject
{
    public static UnityEvent OnPausePressed = new();
    public static void SendPausePressed()
    {
        OnPausePressed?.Invoke();
    }

    public static UnityEvent OnPauseUnpressed = new();
    public static void SendPauseUnpressed()
    {
        OnPauseUnpressed?.Invoke();
    }

    public static UnityEvent OnSavePressed = new();
    public static void SendSavePressed()
    {
        OnSavePressed?.Invoke();
    }

    public static UnityEvent OnLoadPressed = new();
    public static void SendLoadPressed()
    {
        OnSavePressed?.Invoke();
    }
}