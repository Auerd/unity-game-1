using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Awake()
	{
		GlobalEventManager.OnDialogEnded.AddListener(StartAnimationIn);
		GlobalEventManager.OnDialogEnded.AddListener(StartAnimationOut);
	}

	private void StartAnimationIn()
	{
		animator.SetTrigger("StartDialogue");
	}

	private void StartAnimationOut()
	{
		animator.SetTrigger("EndDialogue");
	}
}
