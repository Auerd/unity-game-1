using UnityEngine;

public class BodyManager : AnimationManager
{
	Animator animator;

	private void Start()=>
		animator = GetComponent<Animator>();
	
	public override void In()=>
		animator.SetTrigger("In");

	public override void Out()=>
		animator.SetTrigger("Out");
}
