using UnityEngine;
using static ExternalTools.ChildrenManager;

namespace StateMachineBehaviors
{
	public class OutAnimation : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            SetAllChildrenStateOnObject(animator.transform, false);
    }
}