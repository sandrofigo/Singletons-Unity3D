using UnityEngine;

namespace Singletons
{
    public abstract class SelfInstancingSingleton<T> : Singleton<T> where T : SelfInstancingSingleton<T>
    {
        public new static T Instance
        {
            get
            {
                if (instance == null)
                {
                    new GameObject(typeof(T).Name).AddComponent<T>();
                }

                return instance;
            }
        }
    }
}