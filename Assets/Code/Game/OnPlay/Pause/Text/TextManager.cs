using System.Collections;
using UnityEngine;

public class TextManager : AnimationManager
{
    [SerializeField]
    [Range(0, 1f)]
    private float intervalBetweenButtons;
    [SerializeField]
    private SectionManager primarySection;
    private SectionManager currentSection = null;
    private bool shouldOpenNextSection = false;
    
    public void ChangeSection(SectionManager section)
    {
        StartCoroutine(ChangeSectionCoroutine(section));
    }

    public void StartOpeningNextSection()
    {
        shouldOpenNextSection=true;
    }

    private IEnumerator ChangeSectionCoroutine(SectionManager section)
    {
        if (currentSection != null)
            currentSection.Out(intervalBetweenButtons);
        currentSection = section;
        yield return new WaitUntil(() => shouldOpenNextSection);
        currentSection.In(intervalBetweenButtons);
    }

    public override void In()
    {
        ChangeSection(primarySection);
        shouldOpenNextSection = true;
    }

    public override void Out()
    {
        currentSection.Out(intervalBetweenButtons);
        currentSection = null;
    }
}
