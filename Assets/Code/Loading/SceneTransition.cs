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

	private AsyncOperation LoadingSceneOperation;
	private float progress = 0;

	public TextMeshProUGUI LoadingPercantage;
	public int progressSmooth;


    public static void SwitchToScene(string sceneName)
	{
		instance.animator.SetTrigger("SceneClose");
		instance.LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
		instance.LoadingSceneOperation.allowSceneActivation = false;
	}

	public void OnAnimationOver()
	{
        LoadingSceneOperation.allowSceneActivation = true;
		shouldPlayOpeningAnimation = true;
    }

	void Start()
	{
		animator = GetComponent<Animator>();
		instance = this;
		if(shouldPlayOpeningAnimation) animator.SetTrigger("SceneOpen");
	}

	void Update()
	{
		if(LoadingSceneOperation != null)
		{
			LoadingPercantage.text = Mathf.RoundToInt(Mathf.Lerp(progress, LoadingSceneOperation.progress, progressSmooth)) + "%";
			instance.progress = LoadingSceneOperation.progress;
		}
		if(Mathf.RoundToInt(instance.progress) >= 99.0f) OnAnimationOver();
	}
}
