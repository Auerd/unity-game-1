using UnityEngine;

public class BodyManager : MonoBehaviour, IAnimationManager
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void In()
    {
        animator.SetTrigger("In");
    }

    public void Out()
    {
        animator.SetTrigger("Out");
    }
}
