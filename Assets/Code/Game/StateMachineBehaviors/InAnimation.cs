using UnityEngine;
using static ExternalTools.ChildrenManager;

namespace StateMachineBehaviors
{
	public class InAnimation : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
			SetAllChildrenStateOnObject(animator.transform, true);
	}
}