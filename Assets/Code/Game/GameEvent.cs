using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
	[CreateAssetMenu(fileName = "Game Event")]
	public class GameEvent : ScriptableObject
	{
		private readonly UnityEvent mEvent = new();
		[SerializeField]
		[TextArea(1, 20)]
		[Tooltip(
			"Use at your discretion\n" +
			"Can be useful if there are a lot of objects")]
		private string description;

		public void Raise() =>
			mEvent?.Invoke();
		public void Subscribe(UnityAction action) =>
			mEvent.AddListener(action);
		public void Unsubscribe(UnityAction action) =>
			mEvent.RemoveListener(action);
	}
}
