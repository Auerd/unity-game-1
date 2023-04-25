using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Animator animator;

	private bool dialogueIsGoing = false;
	private bool sentenceIsTyping = false;

	private string currentSentence;
	private Coroutine currentCoroutine;

	[SerializeField]
	private TextMeshProUGUI TextUI;

	[SerializeField]
	[Range(1f, 20f)]
	private float speedOfTyping;

	[HideInInspector]
	public Dialogue CurrentDialogue { private get; set; }

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && CurrentDialogue != null)
		{
			if (!dialogueIsGoing)
			{
				GoInDialogue();
			}
			else
			{
				if (!sentenceIsTyping)
					SetNextSentence();
				else
					DisplayWholeSentence();
			}
		}
	}

	public void SetNextSentence()
	{
		currentSentence = CurrentDialogue.GetNextSentence();
		if (currentSentence != null)
			DisplaySentence(currentSentence);
		else
			GoOutFromDialogue();
	}

	public void EndDialogue() => dialogueIsGoing = false;

	private void DisplaySentence(string sentence)
	{
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);
		currentCoroutine = StartCoroutine(TypeSentence(sentence));
	}

	private void DisplayWholeSentence()
	{
		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);
		TextUI.text = currentSentence;
		sentenceIsTyping = false;
	}

	private IEnumerator TypeSentence(string sentence)
	{
		TextUI.text = "";
		sentenceIsTyping = true;
		foreach (char letter in sentence)
		{
			TextUI.text += letter;
			if (letter != ' ')
				yield return new WaitForSeconds(1 / speedOfTyping);
		}
		sentenceIsTyping = false;
	}

	private void GoOutFromDialogue()
	{
		AnimationOut();
		dialogueIsGoing = false;
		GlobalEventManager.SendPauseUnpressed();
	}

	private void GoInDialogue()
	{
		TextUI.text = "";
		AnimationIn();
		dialogueIsGoing = true;
		GlobalEventManager.SendPausePressed();
		CurrentDialogue.StartNewDialogue();
		// Displaying of first sentence sets in animator
	}

	private void AnimationIn() =>
		animator.SetTrigger("Start");

	private void AnimationOut() =>
		animator.SetTrigger("End");
}
