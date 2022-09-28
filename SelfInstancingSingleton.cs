using UnityEngine;

namespace Singletons
{
    /// <summary>
    /// Automatically spawns a game object and adds the component to it when first accessing the <see cref="Instance"/> of the singleton.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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