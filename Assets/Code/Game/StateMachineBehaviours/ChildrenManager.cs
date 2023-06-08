using UnityEngine;

namespace StateMachineBehaviours
{
    public abstract class ChildrenManager : StateMachineBehaviour
    {
        [SerializeField]
        private protected bool childState;
    }
}
