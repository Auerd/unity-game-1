using UnityEngine;

public class TextManager : MonoBehaviour, IAnimationManager
{
    public float intervalBetweenButtons;
    SectionManager sectionAtNow = null;

    public void GoTo(string sectionName)
    {
        if (sectionAtNow != null)
            sectionAtNow.Out(intervalBetweenButtons);
        if (transform.Find(sectionName).TryGetComponent(out sectionAtNow))
            sectionAtNow.In(intervalBetweenButtons);
    }

    public void In()
    {
        GoTo("Main");
    }

    public void Out()
    {
        sectionAtNow.Out(intervalBetweenButtons);
        sectionAtNow = null;
    }
}
