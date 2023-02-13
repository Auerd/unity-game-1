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
        StartCoroutine(GoManagerInWithInterval(interval));
    }

    public void Out(float interval)
    {
        StartCoroutine(GoManagerOutWithInterval(interval));
    }

    IEnumerator GoManagerInWithInterval(float interval)
    {
        foreach (var manager in managersOfButtons)
        {
            manager.In();
            yield return new WaitForSeconds(interval);
        }
        yield break;
    }

    IEnumerator GoManagerOutWithInterval(float interval)
    {
        foreach (var manager in managersOfButtons)
        {
            manager.Out();
            yield return new WaitForSeconds(interval);
        }
        yield break;
    }
}
