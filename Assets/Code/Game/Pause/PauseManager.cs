using System.Collections;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	IAnimationManager[] animationManagers;

	bool pauseIsGoing = false;

	void Start()
	{
		animationManagers = GetComponentsInChildren<IAnimationManager>();
	}

	void Update()
	{
		if (Input.GetKey("escape") && !pauseIsGoing)
		{
			pauseIsGoing = true;
			GlobalEventManager.SendPausePressed();
			In();
		}
	}

	public void StartAnimationOut()
	{
		pauseIsGoing = false;
		Out();
        GlobalEventManager.SendPauseUnpressed();
    }

	void In()
	{
		foreach(IAnimationManager animationManager in animationManagers)
		{
			animationManager.In();
		}
	}

	void Out()
	{
		foreach(IAnimationManager animationManager in animationManagers)
		{
			animationManager.Out();
		}
    }
}
