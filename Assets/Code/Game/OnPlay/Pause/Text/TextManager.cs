using System.Collections;
using UnityEngine;

public class TextManager : MonoBehaviour, IAnimationManager
{
	[SerializeField]
	[Range(0, 1f)]
	private float intervalBetweenButtons;
	[SerializeField]
	private SectionManager primarySection;
	private SectionManager currentSection = null;
	private bool shouldOpenNextSection = false;
	bool isAnimating = false;

	public void GoToSection(SectionManager section)=>
		StartCoroutine(GoToSectionCoroutine(section));

	public void StartOpeningNextSection()=> 
		shouldOpenNextSection = true;

	private IEnumerator GoToSectionCoroutine(SectionManager section)
	{
		if (currentSection != null)
			currentSection.Out(intervalBetweenButtons);
		currentSection = section;
		yield return new WaitUntil(() => shouldOpenNextSection);
		currentSection.In(intervalBetweenButtons);
		shouldOpenNextSection = false;
	}

	public void In()
	{
		GoToSection(primarySection);
		shouldOpenNextSection = true;
	}

	public void Out()
	{
		currentSection.Out(intervalBetweenButtons);
		currentSection = null;
	}

	public bool GetAnimatingState()=>
		isAnimating;
}
