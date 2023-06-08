using UnityEngine;

namespace StateMachineBehaviours
{
    internal class SelfDisableOnExit : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.gameObject.SetActive(false);
        }
    }
}
