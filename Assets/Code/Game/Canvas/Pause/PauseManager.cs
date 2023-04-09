using UnityEngine;

public class PauseManager : MonoBehaviour
{
	IAnimationManager[] animationManagers;

	private bool pauseIsGoing = false;

    private void Start()
	{
		animationManagers = GetComponentsInChildren<IAnimationManager>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape) && !pauseIsGoing)
		{
			pauseIsGoing = true;
			GlobalEventManager.SendPausePressed();
			AnimationIn();
		}
	}

	public void GoPauseOut()
	{
		pauseIsGoing = false;
		AnimationOut();
        GlobalEventManager.SendPauseUnpressed();
    }

	void AnimationIn()
	{
		foreach(IAnimationManager animationManager in animationManagers)
		{
			animationManager.In();
		}
	}

	void AnimationOut()
	{
		foreach(IAnimationManager animationManager in animationManagers)
		{
			animationManager.Out();
		}
    }
}
