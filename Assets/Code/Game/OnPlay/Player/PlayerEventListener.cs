using UnityEngine;
using EventSystem;

public class PlayerEventListener : MonoBehaviour
{
    PlayerControl playerControl;
    Animator animator;
    [Header("Pause Listeners")]
    [SerializeField]
    GameEvent onPausePressed;
    [SerializeField]
    GameEvent onResumePressed;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        onPausePressed.Subscribe(Stop);
        onPausePressed.Subscribe(Continue);
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
