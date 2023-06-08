using UnityEngine;

namespace ExternalTools
{
    public static class ChildrenManager
    {
        public static void SetAllChildrenStateOnObject(Transform transform, bool state)
        {
            foreach(Transform child in transform)
                child.gameObject.SetActive(state);
        }
    }
}
