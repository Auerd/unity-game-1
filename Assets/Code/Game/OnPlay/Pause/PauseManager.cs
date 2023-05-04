using EventSystem;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	IAnimationManager[] animationManagers;

	[SerializeField]
	GameEvent onPausePressed;
	[SerializeField]
	GameEvent onResumePressed;

	private bool pauseIsGoing = false;

	private void Start()=>
		animationManagers = GetComponentsInChildren<IAnimationManager>();

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pauseIsGoing)
			{
				pauseIsGoing = true;
				onPausePressed.Raise();
				AnimationIn();
			}
			else
				GoPauseOut();
		}
	}

	public void GoPauseOut()
	{
		pauseIsGoing = false;
		AnimationOut();
		onResumePressed.Raise();
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
