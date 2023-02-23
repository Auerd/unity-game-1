using UnityEngine;

public class PlayerEventListener : MonoBehaviour
{
    PlayerControl playerControl;
    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        GlobalEventManager.OnPausePressed.AddListener(Stop);
        GlobalEventManager.OnPauseUnpressed.AddListener(Continue);
        GlobalEventManager.OnDialogStarted.AddListener(Stop);
        GlobalEventManager.OnDialogEnded.AddListener(Continue);
        GlobalEventManager.OnSavePressed.AddListener(Save);
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

    void Save()
    {
        SaveManager.Save(transform.name, rb);
    }
}
