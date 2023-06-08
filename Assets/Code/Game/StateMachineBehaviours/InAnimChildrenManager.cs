using UnityEngine;
using static ExternalTools.ChildrenManager;

namespace StateMachineBehaviours
{
	public class InAnimChildrenManager : ChildrenManager
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			SetAllChildrenStateOnObject(animator.transform, childState);
		}
	}
}