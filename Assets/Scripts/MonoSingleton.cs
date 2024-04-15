using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get 
        {
            if (_instance == null)
            {
                T i = FindObjectOfType<T>();
                if (i == null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }
                else 
                {
                    _instance = i;
                }
            }
            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}