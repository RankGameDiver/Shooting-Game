using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// PlayerInput.cs는 PlayerInput과 같은 위치에 있어야만 InputActionAsset에서 설정한 대로 Send Messages를 받을 수 있음
/// </summary>
public class PlayerInput : MonoBehaviour
{
    private PlayerFacade _playerFacade;

    public void Init(PlayerFacade playerFacade)
    {
        _playerFacade = playerFacade;
    }

    public void OnFoward(InputValue value)
    {
        _playerFacade.OnFoward(value.isPressed);
    }

    public void OnBack(InputValue value)
    {
        _playerFacade.OnBack(value.isPressed);
    }

    public void OnLeft(InputValue value)
    {
        _playerFacade.OnLeft(value.isPressed);
    }

    public void OnRight(InputValue value)
    {
        _playerFacade.OnRight(value.isPressed);
    }

    public void OnBooster(InputValue value)
    {
        _playerFacade.OnBooster(value.isPressed);
    }
}
