using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Animator animator;

	private bool dialogueIsGoing = false;

	private DialogueTrigger currentDialogueTrigger = null;

    [SerializeField]
	private TextMeshProUGUI text;

    public Transform player;

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
