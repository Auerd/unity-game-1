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

	public TextMeshProUGUI LoadingPercantage;

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
			LoadingPercantage.text = Mathf.RoundToInt(LoadingSceneOperation.progress) + "%";
	}
}
