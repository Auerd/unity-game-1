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
	private float progress = 0;

	public TextMeshProUGUI LoadingPercantage;
	public int progressSmooth;

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
		ChildObjectsDisable();
    }

    public static void SwitchToScene(string sceneName)
	{
		instance.ChildObjectsAble();
        instance.animator.SetTrigger("SceneClose");
		instance.LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
		instance.LoadingSceneOperation.allowSceneActivation = false;
	}

	public void OnAnimationOver()
	{
        instance.LoadingSceneOperation.allowSceneActivation = true;
        shouldPlayOpeningAnimation = true;
    }

	void Update()
	{
		if(instance.LoadingSceneOperation != null)
		{
            progress = Mathf.Lerp(progress, LoadingSceneOperation.progress, progressSmooth);
            instance.LoadingPercantage.text = Mathf.RoundToInt(progress*100) + "%";
		}
		if(Mathf.RoundToInt(progress)*100 == 100) OnAnimationOver();
	}
}
