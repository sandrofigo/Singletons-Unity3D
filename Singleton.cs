using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singletons
{
    /// <summary>
    /// Used for <see cref="MonoBehaviour"/>.
    /// </summary>
    /// <remarks>By default the instance is only active in the scene where it was created. To persist the instance over multiple scene loads call <see cref="DontDestroyOnLoad"/>.</remarks>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;

        private bool keep;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                        Debug.LogError($"The singleton ({typeof(T).Name}) you were trying to access was not part of the scene! Add the component to a game object in the scene and try again.");
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;

                SceneManager.sceneUnloaded += OnSceneUnloaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            if (!keep)
                instance = null;
        }

        protected void DontDestroyOnLoad()
        {
            DontDestroyOnLoad(gameObject);
            keep = true;
        }
    }
}