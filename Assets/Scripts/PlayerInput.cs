using UnityEngine;
using UnityEngine.InputSystem;

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
}
