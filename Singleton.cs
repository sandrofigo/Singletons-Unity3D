using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singletons
{
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        protected static T instance;

        private bool keep;

        private string exclusiveScene;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogWarning($"The singleton ({typeof(T).Name}) you were trying to access was not part of the scene! Add the component to a game object first and try again.");
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

            if (!string.IsNullOrEmpty(exclusiveScene))
            {
                if (this == null)
                    return;

                Destroy(gameObject);
                instance = null;
            }
        }

        protected void DontDestroyOnLoad()
        {
            DontDestroyOnLoad(gameObject);
            keep = true;
        }

        protected void SetExclusiveScene(string sceneName)
        {
            exclusiveScene = sceneName;
        }
    }
}