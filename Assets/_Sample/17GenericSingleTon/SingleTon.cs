using UnityEngine;

namespace Sample
{
    public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
    {
        static T instance;

        public static T Instance
        { 
            get {return instance;}
        }

        public static bool InstanceExist
        {
            get { return instance != null; }
        }
        protected virtual void Awake()
        {
            if (InstanceExist)
            { 
                Destroy(gameObject);
                return;
            }
            instance = (T)this;
        }
  
    }
}