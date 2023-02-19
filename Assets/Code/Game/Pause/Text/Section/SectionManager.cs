using System.Collections;
using TMPro;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    TextButtonManager[] managersOfButtons;

    private void Start()
    {
        managersOfButtons = GetComponentsInChildren<TextButtonManager>();
    }

    public void In(float interval)
    {
        StartCoroutine(GoManagerWithInterval(ToDo.In, interval));
    }

    public void Out(float interval)
    {
        StartCoroutine(GoManagerWithInterval(ToDo.Out, interval));
    }

    IEnumerator GoManagerWithInterval(ToDo toDo, float interval)
    {
        foreach (var manager in managersOfButtons)
        {
            manager.Do(toDo);
            yield return new WaitForSeconds(interval);
        }
        yield break;
    }
}
