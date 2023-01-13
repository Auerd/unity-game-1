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
	private float smooth = 0;

	
	public TextMeshProUGUI LoadingPercentage;
	public float multiplier;
	public float durationOfPercentTransition;


	Start()
	{
		instance = this;
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
		if (shouldPlayOpeningAnimation) animator.SetTrigger("SceneOpen");
		else ChildObjectsDisable();
		instance.LoadingPercentage.text = Mathf.RoundToInt(visibleProgress * 100) + "%";
	}

	Update()
	{
		if (instance.LoadingSceneOperation != null)
		{
			/* I put /0.9f 'cause progress does not finish on 1. It finishes on 0.9 */
			realProgress = LoadingSceneOperation.progress / 0.9f;
			if (visibleProgress < realProgress)
			{
				visibleProgress = Mathf.Lerp(visibleProgress, realProgress, Mathf.Pow(smooth, multiplier));

				smooth += Time.deltaTime / durationOfPercentTransition;
			}

			if (Mathf.RoundToInt(visibleProgress * 100) >= Mathf.RoundToInt(realProgress * 100))
			{
				visibleProgress = realProgress;
				smooth = 0;
			}

			instance.LoadingPercentage.text = Mathf.RoundToInt(visibleProgress * 100) + "%";
			if (Mathf.RoundToInt(visibleProgress * 100) == 100) OnAnimationOver();
		}
	}

	private void OnAnimationOver()
	{
		shouldPlayOpeningAnimation = true;
		instance.LoadingSceneOperation.allowSceneActivation = true;
	}

	public static void SwitchToScene(string sceneName)
	{
		instance.animator.SetTrigger("SceneClose");
        instance.ChildObjectsAble();
        instance.LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
		instance.LoadingSceneOperation.allowSceneActivation = false;
		visibleProgress = 0;
	}

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
}
