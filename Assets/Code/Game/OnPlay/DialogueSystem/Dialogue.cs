using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
	[System.Serializable]
	public class Dialogue
	{
		[SerializeField]
		private Sentence[] sentences;
		private readonly Queue<Sentence> sentencesQueue = new();

		public Sentence GetNextSentence()
		{
			if (sentencesQueue.Count != 0)
				return sentencesQueue.Dequeue();
			return null;
		}
		public void StartNewDialogue()
		{
			sentencesQueue.Clear();
			foreach (Sentence sentence in sentences)
				sentencesQueue.Enqueue(sentence);
		}
	}
}
