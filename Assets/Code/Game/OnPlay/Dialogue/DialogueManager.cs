using EventSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
	public class DialogueManager : MonoBehaviour
	{
		private Animator animator;

		private bool dialogueIsGoing = false;
		private bool sentenceIsTyping = false;

		private Sentence currentSentence;
		private Coroutine currentCoroutine;

		[SerializeField]
		private TextMeshProUGUI textField;
		[SerializeField]
        private TextMeshProUGUI personNameField;
		[SerializeField]
		private GameEvent dialogueStarted;
		[SerializeField] 
		private GameEvent dialogueEnded;

		[SerializeField]
		[Range(1f, 20f)]
		private float speedOfTyping;

		[HideInInspector]
		public Dialogue CurrentDialogue { private get; set; }

		void Start()=>
			animator = GetComponent<Animator>();

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E) && CurrentDialogue != null)
			{
				if (!dialogueIsGoing)
				{
					StartDialogue();
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
				EndDialogue();
		}

		private void DisplaySentence(Sentence sentence)
		{
			if (currentCoroutine != null)
				StopCoroutine(currentCoroutine);
			personNameField.text = sentence.person.Name;
			currentCoroutine = StartCoroutine(TypeSentence(sentence));
		}

		private void DisplayWholeSentence()
		{
			if (currentCoroutine != null)
				StopCoroutine(currentCoroutine);
			textField.text = currentSentence.words;
			sentenceIsTyping = false;
		}

		private IEnumerator TypeSentence(Sentence sentence)
		{
			textField.text = "";
			sentenceIsTyping = true;
			foreach (char letter in sentence.words)
			{
				textField.text += letter;
				if (letter != ' ')
					yield return new WaitForSeconds(1 / speedOfTyping);
			}
			sentenceIsTyping = false;
		}

		private void EndDialogue()
		{
			AnimationOut();
			dialogueIsGoing = false;
			dialogueEnded.Raise();
		}

		private void StartDialogue()
		{
			textField.text = "";
			AnimationIn();
			dialogueIsGoing = true;
			dialogueStarted.Raise();
			CurrentDialogue.StartNewDialogue();
			// Time of displaying first sentence sets in animator
		}

		private void AnimationIn() =>
			animator.SetTrigger("Start");

		private void AnimationOut() =>
			animator.SetTrigger("End");
	}
}