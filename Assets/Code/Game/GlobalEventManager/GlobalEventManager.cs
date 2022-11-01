using UnityEngine.Events;

public class GlobalEventManager
{
    // Pressing pause event
    public static UnityEvent OnPausePressed = new UnityEvent();
    public static void SendPausePressed()
    {
        if (OnPausePressed != null) OnPausePressed.Invoke();
    }


    // Unpressing pause event
    public static UnityEvent OnPauseUnpressed = new UnityEvent();
    public static void SendPauseUnpressed()
    {
        if (OnPauseUnpressed != null) OnPauseUnpressed.Invoke();
    }
}
