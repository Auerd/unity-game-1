using UnityEngine;
using static ExternalTools.ChildrenManager;

namespace StateMachineBehaviours
{
	public class OutAnimChildrenManager : ChildrenManager
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
            SetAllChildrenStateOnObject(animator.transform, childState);
    }
}