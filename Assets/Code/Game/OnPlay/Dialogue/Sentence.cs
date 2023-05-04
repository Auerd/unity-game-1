using UnityEngine;

namespace DialogueSystem
{
	[System.Serializable]
	public class Sentence
	{
		public Person person;
		[TextArea(3, 5)]
		public string words;
	}
}