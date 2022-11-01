using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic;
    public float offset;
    private float sortingOrderBase = 0;
    Renderer renderer_;
    private void Awake()
    {
        renderer_ = GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        renderer_.sortingOrder = (int)(sortingOrderBase - transform.position.y * 8 + offset);
        if (isStatic)
            Destroy(this);
    }
}
