using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextButtonManager : MonoBehaviour
{
	Animator animator;
	TextMeshProUGUI textMeshPro;
	Button button;

	void Start()
	{
		animator = GetComponent<Animator>();
		textMeshPro = GetComponent<TextMeshProUGUI>();
		button = GetComponent<Button>();
		textMeshPro.alpha = 0;
		GoButtonOff();
	}


	void In()
	{
		animator.SetTrigger("In");
	}

	void Out()
	{
		animator.SetTrigger("Out");
	}

	public void Do(ToDo toDo)
	{
		switch(toDo)
		{
			case ToDo.In: In(); break; 
			case ToDo.Out: Out(); break;
		}
	}

	public void GoButtonOff() 
	{ 
		button.enabled = false;
	}

	public void GoButtonOn()
	{
		button.enabled = true; 
	}
}
