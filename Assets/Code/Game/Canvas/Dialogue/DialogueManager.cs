using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	Animator animator;
	private bool dialogueIsGoing = false;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !dialogueIsGoing)
		{ 
			dialogueIsGoing=true;
			GlobalEventManager.SendPausePressed();
			AnimationIn();
		}
    }

    private void AnimationIn()
	{
		animator.SetTrigger("Start");
	}

	private void AnimationOut()
	{
		animator.SetTrigger("End");
	}
}
