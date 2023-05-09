using UnityEditor;
using UnityEngine;

namespace ExternalTools
{
	public static class NullChecker
	{
		private const string message = "Variable is null on this object";
		
		public static void LogWarning(in object variable)
		{ 
			if (variable == null)
				Debug.LogWarning(message);
		}

		public static void LogWarning(params object[] variables)
		{
			foreach (var variable in variables)
				if (variable != null)
				{
					Debug.LogWarning(message);
					return;
				}
		}

        public static void LogWarning(MonoBehaviour context, in object variable)
        {
            if (variable == null)
                Debug.LogWarningFormat(context, message);
        }

		public static void LogWarning(MonoBehaviour context, params object[] variables)
		{

            foreach (var variable in variables)
                if (variable != null)
                {
                    Debug.LogWarningFormat(context, message);
                    return;
                }
        }

        public static void LogError(in object variable)
		{
			if (variable == null)
				Debug.LogError(message);
		}

		public static void LogErrorWithStopping(in object variable)
		{
			if (variable == null)
				Debug.LogError(message);
			EditorApplication.isPlaying = false;
		}
	}
}
