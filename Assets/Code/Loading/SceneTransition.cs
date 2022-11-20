using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	private static SceneTransition instance;
	private static bool shouldPlayOpeningAnimation = false;

	private Animator animator;
	private new Transform transform;

	private AsyncOperation LoadingSceneOperation;

    private static float visibleProgress;
	private float realProgress;
	private float t = 0;

	
	public TextMeshProUGUI LoadingPercentage;
	public float multiplier;
	public float durationOfPercentTransition;


    private void ChildObjectsDisable()
    {
        transform.Find("Image").gameObject.SetActive(false);
        transform.Find("LoadingBlock").gameObject.SetActive(false);
    }
    private void ChildObjectsAble()
    {
        transform.Find("Image").gameObject.SetActive(true);
        transform.Find("LoadingBlock").gameObject.SetActive(true);
    }


    void Start()
	{
		instance = this;
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
		if (shouldPlayOpeningAnimation) animator.SetTrigger("SceneOpen");
		else ChildObjectsDisable();
        instance.LoadingPercentage.text = Mathf.RoundToInt(visibleProgress * 100) + "%";
        Debug.Log(visibleProgress);
	}

	public static void SwitchToScene(string sceneName)
	{
		instance.animator.SetTrigger("SceneClose");
		instance.LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
		instance.LoadingSceneOperation.allowSceneActivation = false;
		visibleProgress = 0;
		instance.ChildObjectsAble();
	}

	private void OnAnimationOver()
	{
		shouldPlayOpeningAnimation = true;
		instance.LoadingSceneOperation.allowSceneActivation = true;
	}

	void Update()
	{
		if(instance.LoadingSceneOperation != null)
		{
			/* I put /0.9f 'cause progress not finishes on 1. It finishes on 0.9 */
			realProgress = LoadingSceneOperation.progress / 0.9f;
			if (visibleProgress < realProgress) 
			{
				visibleProgress = Mathf.Lerp(visibleProgress, realProgress, Mathf.Pow(t, multiplier));

				t += Time.deltaTime/durationOfPercentTransition;
			}

			if(visibleProgress >= realProgress)
			{
				visibleProgress = realProgress;
			}

			instance.LoadingPercentage.text = Mathf.RoundToInt(visibleProgress * 100) + "%";
			if (Mathf.RoundToInt(visibleProgress*100) == 100) OnAnimationOver();
		}
	}
}
