using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject _uiPlayerDied;

    void Awake()
    {
        _uiPlayerDied.SetActive(false);
    }

    public void PlayerDied(bool enable)
    {
        _uiPlayerDied.SetActive(enable);
    }
}
