using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class BodyManager : MonoBehaviour, IAnimationManager
{
	private new Renderer renderer;

	[SerializeField] 
	private Material material;

	private void Start()
	{
		material = GetComponent<Material>();
	}
	public void In()
	{
		
	}

	public void Out()
	{
		
	}
}
