using UnityEngine;

public class GoInOutPause : MonoBehaviour
{
    Animator animator;

    bool pause_is_going = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey("escape") && !pause_is_going)
        {
            animator.SetTrigger("pauseStart");
            pause_is_going = true;
        }
    }
    public void OnClick()
    {
        animator.SetTrigger("pauseEnd");
        pause_is_going = false;
    }
}
