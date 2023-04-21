using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Animator animator;

	private bool dialogueIsGoing = false;

    [SerializeField]
	private TextMeshProUGUI TextUI;

	[HideInInspector]
	public Dialogue currentDialogue;

    void Start()
	{
		animator = GetComponent<Animator>();
	}

    private void Update()
    {
		if(Input.GetKeyDown(KeyCode.E))
		{
        	if(!dialogueIsGoing && currentDialogue != null)
			{ 
				dialogueIsGoing=true;
				GlobalEventManager.SendPausePressed();
				AnimationIn();
			} else if(dialogueIsGoing)
			{
				
			}
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

	private void GetLineOfDialogue()
	{
		TextUI.text = currentDialogue.GetNextSentence();
	}
}
