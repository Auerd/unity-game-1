using System.Collections;
using UnityEditor;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
	TextButtonManager[] managersOfButtons;
	TextManager textManager;

	private void Start()
	{
		managersOfButtons = GetComponentsInChildren<TextButtonManager>();
		textManager = GetComponentInParent<TextManager>();
#if UNITY_EDITOR
		if(textManager == null)
		{
			Debug.LogError("Section " + transform.name + " is not in parent with TextManager");
			EditorApplication.isPlaying = false;
		}
#endif
	}

	public void In(float interval)
	{
		StartCoroutine(AnimateInWithInterval(interval));
	}

	public void Out(float interval)
	{
        StartCoroutine(AnimateOutWithInterval(interval));
	}

	IEnumerator AnimateInWithInterval(float interval)
	{
        SetAllChildrenActive(true);
        foreach (var manager in managersOfButtons)
		{
			manager.In();
			yield return new WaitForSeconds(interval);
		}
	}
	
	IEnumerator AnimateOutWithInterval(float interval)
	{
		foreach (var manager in managersOfButtons)
		{ 
			manager.Out();
			yield return new WaitForSeconds(interval);
		}
        textManager.StartOpeningNextSection();
    }

	void SetAllChildrenActive(bool active)
	{
		foreach (Transform child in transform)
			child.gameObject.SetActive(active);
	}
}
