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
                    Debug.LogError("scene안에 해당하는 컴포넌트가 없습니다. name L " + typeof(T).Name);
                else 
                    _instance = i;
            }
            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}