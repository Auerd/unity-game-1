using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ToDo
{
    In, Out
}

public class TextButtonManager : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI textMeshPro;
    Button button;

    private void Start()
    {
        animator = GetComponent<Animator>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        textMeshPro.alpha = 0;
        button.enabled = false;
    }

    void In()
    {
        animator.SetTrigger("In");
        button.enabled = true;
    }

    void Out()
    {
        button.enabled = false;
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
}
