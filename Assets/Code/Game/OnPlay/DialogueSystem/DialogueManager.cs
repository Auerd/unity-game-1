using EventSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
	[RequireComponent(typeof(Animator))]
	public class DialogueManager : MonoBehaviour
	{
		private Animator animator;

		[SerializeField]
		[HideInInspector]
		private bool dialogueIsGoing = false;

		private bool sentenceIsTyping = false;
 
		private Sentence currentSentence;
		private Coroutine currentTyping;

        [SerializeField] private TextMeshProUGUI textField;
		[SerializeField] private TextMeshProUGUI personNameField;
		[SerializeField] private GameEvent dialogueStarted;
		[SerializeField] private GameEvent dialogueEnded;

		[SerializeField]
		[Range(1f, 20f)]
		private float speedOfTyping;

		[HideInInspector]
		public Dialogue CurrentDialogue { private get; set; }

		void Start() => 
			animator = GetComponent<Animator>();

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E) && CurrentDialogue != null)
			{
				if (!dialogueIsGoing)
					StartDialogue();
				else
				{
					if (!sentenceIsTyping)
						SetNextSentence();
					else
						DisplayWholeSentence();
				}
			}
		}


		private void DisplayWholeSentence()
		{
			if (currentTyping != null)
				StopCoroutine(currentTyping);
			textField.text = currentSentence.words;
			sentenceIsTyping = false;
		}

		private void SetNextSentence()
		{
			currentSentence = CurrentDialogue.GetNextSentence();
			if (currentSentence != null)
				DisplaySentence(currentSentence);
			else
				EndDialogue();
		}

		private void DisplaySentence(Sentence sentence)
		{
			if (currentTyping != null)
				StopCoroutine(currentTyping);
			personNameField.text = sentence.person.Name;
			currentTyping = StartCoroutine(TypeSentence(sentence));
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
            dialogueEnded.Raise();
		}

		private void CleanUp()
		{
			currentTyping = null;
			currentSentence = null;
			personNameField.text = "";
            textField.text = "";
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