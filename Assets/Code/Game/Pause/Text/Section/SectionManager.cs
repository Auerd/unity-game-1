using System.Collections;
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
        SetAllChildrenActive(true);
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
    }

    void SetAllChildrenActive(bool active)
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(active);
    }
}
