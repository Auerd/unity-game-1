using UnityEngine;

namespace DialogueSystem
{
	[CreateAssetMenu(fileName = "Person")]
	[System.Serializable]
	public class Person : ScriptableObject
	{
		[SerializeField]
		private new string name;
		public string Name { get { return name; } }
	}
}
