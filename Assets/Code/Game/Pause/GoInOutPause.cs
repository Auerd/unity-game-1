using UnityEngine;

public class GoInOutPause : MonoBehaviour
{
	Animator animator;

	bool pauseIsGoing = false;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetKey("escape") && !pauseIsGoing)
		{
			animator.SetTrigger("pauseStart");
			pauseIsGoing = true;
			GlobalEventManager.SendPausePressed();
		}
	}
	public void StartAnimationOut()
	{
		animator.SetTrigger("pauseEnd");
		pauseIsGoing = false;
	}

	public void OnAnimationOver()
	{
		GlobalEventManager.SendPauseUnpressed();
    }
}
