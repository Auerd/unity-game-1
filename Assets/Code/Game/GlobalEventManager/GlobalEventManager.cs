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

	// Dialogue
	public static UnityEvent OnDialogStarted = new UnityEvent();
	public static void SendDialogStarted()
	{
		if (OnDialogStarted != null) OnDialogStarted.Invoke();
	}

	public static UnityEvent OnDialogEnded = new UnityEvent();
	public static void SendDialogEnded()
	{
		if (OnDialogEnded != null) OnDialogEnded.Invoke();
	}
}
