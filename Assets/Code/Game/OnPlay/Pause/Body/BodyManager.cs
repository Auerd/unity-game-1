using UnityEngine;

public class BodyManager : MonoBehaviour, IAnimationManager
{
	Animator animator;
	[HideInInspector]
	[SerializeField]
	bool isAnimating = false;

	private void Start()=>
		animator = GetComponent<Animator>();
	
	public void In()=>
		animator.SetTrigger("In");

	public void Out()=>
		animator.SetTrigger("Out");
	
	public bool GetAnimatingState()=>
		isAnimating;
}
