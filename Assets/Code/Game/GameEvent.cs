using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
	[CreateAssetMenu(fileName = "Game Event")]
	public class GameEvent : ScriptableObject
	{
		private readonly UnityEvent mEvent;

		public void Raise() =>
			mEvent?.Invoke();
		public void Subscribe(UnityAction action) =>
			mEvent.AddListener(action);
		public void Unsubscribe(UnityAction action) =>
			mEvent.RemoveListener(action);
	}
}
