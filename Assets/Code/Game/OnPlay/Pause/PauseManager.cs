using UnityEngine;

public class PauseManager : MonoBehaviour
{
	IAnimationManager[] animationManagers;
	private bool isAnimating = false;
	private bool pauseIsGoing = false;

	private void Start()
	{
		animationManagers = GetComponentsInChildren<IAnimationManager>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pauseIsGoing && !isAnimating)
			{
				pauseIsGoing = true;
				GlobalEventManager.SendPausePressed();
				AnimationIn();
				Debug.Log("Paused");
			}
			else
				GoPauseOut();
		}
	}

	public void GoPauseOut()
	{
		if (!isAnimating)
		{
			pauseIsGoing = false;
			AnimationOut();
			GlobalEventManager.SendPauseUnpressed();
		}
	}

	void AnimationIn()
	{
		foreach (IAnimationManager animationManager in animationManagers)
		{
			animationManager.In();
		}
	}

	void AnimationOut()
	{
		foreach (IAnimationManager animationManager in animationManagers)
		{
			animationManager.Out();
		}
	}
}
