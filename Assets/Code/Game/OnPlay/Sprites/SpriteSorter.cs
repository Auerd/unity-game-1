using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic;
    public float offset;
    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(offset - transform.position.y * 8);
        if (isStatic)
            Destroy(this);
    }
}
