using UnityEngine;
using static GlobalEventManager;

public class PlayerEventListener : MonoBehaviour
{
    PlayerControl playerControl;
    Animator animator;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        OnPausePressed.AddListener(Stop);
        OnPauseUnpressed.AddListener(Continue);
    }

    void Stop()
    {
        animator.enabled = false;
        playerControl.enabled = false;
    }

    void Continue()
    {
        animator.enabled = true;
        playerControl.enabled = true;
    }
}
