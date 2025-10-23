using UnityEngine;

namespace Sample
{
    public class PersistantSingleton<T> : SingleTon<T> where T : SingleTon<T>
    {
        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this.gameObject);
        }
    }
}