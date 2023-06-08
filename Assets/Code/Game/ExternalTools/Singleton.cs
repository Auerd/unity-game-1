using System.Collections;
using UnityEngine;

namespace ExternalTools
{
    public abstract class Singleton : MonoBehaviour
    {
        protected Singleton instance;
        protected Singleton() {}
        public Singleton Instance { get { return instance; } }
    }
}