public abstract class AnimationManager : UnityEngine.MonoBehaviour
{
    private protected bool isAnimating = false;
    public abstract void In();
    public abstract void Out();
    public bool IsAnimating { get { return isAnimating; } }
}
