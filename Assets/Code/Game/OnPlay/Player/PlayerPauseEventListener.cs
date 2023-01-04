using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseEventListener : MonoBehaviour
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
        GlobalEventManager.OnPausePressed.AddListener(Stop);
        GlobalEventManager.OnPauseUnpressed.AddListener(Continue);
        GlobalEventManager.OnDialogStarted.AddListener(Stop);
        GlobalEventManager.OnDialogEnded.AddListener(Continue);
    }

    private void Stop()
    {
        animator.enabled = false;
        playerControl.enabled = false;
    }

    private void Continue()
    {
        animator.enabled = true;
        playerControl.enabled = true;
    }
}
