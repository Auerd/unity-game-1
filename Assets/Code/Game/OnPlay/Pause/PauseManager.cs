using EventSystem;
using ExternalTools;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	AnimationManager[] animationManagers;

	[SerializeField]
	GameEvent onPausePressed;
	[SerializeField]
	GameEvent onResumePressed;

	private bool pauseIsGoing = false;

	private void Start()
	{
		NullChecker.LogWarning(this, onPausePressed);
		animationManagers = GetComponentsInChildren<AnimationManager>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pauseIsGoing)
				AblePause();
			else
				DisablePause();
		}
	}

	public void DisablePause()
	{
		pauseIsGoing = false;
		AnimationOut();
		onResumePressed.Raise();
	}

	private void AblePause()
	{
        pauseIsGoing = true;
        onPausePressed.Raise();
        AnimationIn();
    }

	void AnimationIn()
	{
		foreach (AnimationManager animationManager in animationManagers)
			animationManager.In();
	}

	void AnimationOut()
	{
		foreach (AnimationManager animationManager in animationManagers)
			animationManager.Out();
	}
}
