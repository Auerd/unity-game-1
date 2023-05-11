using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Mathf;

public class SceneTransition : MonoBehaviour
{
	[System.Serializable]
	private struct TransitionSettings
	{
		public float easing;
		[Range(0.1f, 100f)]
		public float duration;
	}
	// Singleton pattern
	private static SceneTransition instance;
	private static bool shouldPlayOpeningAnimation = false;
	private static float visibleProgress;

	private Animator animator;
	private new Transform transform;
	private AsyncOperation LoadingSceneOperation;

	private float realProgress;
	private float t = 0;

	[SerializeField]
	private TextMeshProUGUI LoadingPercentage;
	[SerializeField]
	private TransitionSettings transitionSettings;

	void Start()
	{
		instance = this;
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
		if (shouldPlayOpeningAnimation)
		{
			animator.SetTrigger("SceneOpen");
			instance.LoadingPercentage.text = 100 + "%";
		}
		else
		{
			SetChildrenState(false);
			instance.LoadingPercentage.text = 0 + "%";
		}
	}

	void Update()
	{
		if (instance.LoadingSceneOperation != null)
			ManageLoading();
	}

	private void ManageLoading()
	{
		/* I put /0.9f 'cause progress not finishes on 1, but on 0.9 */
		realProgress = LoadingSceneOperation.progress / 0.9f;
		if (RoundToInt(visibleProgress * 100) < RoundToInt(realProgress * 100))
		{
			visibleProgress = Lerp(visibleProgress, realProgress, Pow(t, transitionSettings.easing));

			t += Time.deltaTime / transitionSettings.duration;
		}
		else
		{
			visibleProgress = realProgress;

			t = 0;
		}

		instance.LoadingPercentage.text = RoundToInt(visibleProgress * 100) + "%";

		if (RoundToInt(visibleProgress * 100) == 100) OnAnimationOver();
	}

	public static void SwitchToScene(string sceneName)
	{
		instance.animator.SetTrigger("SceneClose");
		instance.SetChildrenState(true);
		instance.LoadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
		instance.LoadingSceneOperation.allowSceneActivation = false;
		visibleProgress = 0;
	}

	private void SetChildrenState(bool state)
	{
		foreach (Transform child in transform)
			child.gameObject.SetActive(state);
	}

	private void OnAnimationOver()
	{
		shouldPlayOpeningAnimation = true;
		instance.LoadingSceneOperation.allowSceneActivation = true;
	}
}
