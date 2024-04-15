using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGameScene : MonoBehaviour
{
    public void OnLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
