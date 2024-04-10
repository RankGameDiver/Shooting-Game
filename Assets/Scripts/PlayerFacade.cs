using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerFacade : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;

    void Awake() 
    {
        SpriteResolver spriteResolver = GetComponentInChildren<SpriteResolver>();
        _playerAnimation = new PlayerAnimation(spriteResolver);
        _playerAnimation.SetUpdateTime(0.03f);

        _playerInput = GetComponentInChildren<PlayerInput>();
        _playerInput.Init(this);

        _playerMovement = new PlayerMovement(0.02f, gameObject);
    }

    void Update() 
    {
        _playerMovement.OnUpdate();
        _playerAnimation.SetDirectionX(_playerMovement.GetDirection().x);
        _playerAnimation.OnUpdate();
    }

    public void OnFoward(bool isPressed)
    {
        _playerMovement.SetDirectionX(isPressed);
    }

    public void OnBack(bool isPressed)
    {
        _playerMovement.SetDirectionX(!isPressed);
    }

    public void OnLeft(bool isPressed)
    {
        _playerMovement.SetDirectionY(!isPressed);
    }

    public void OnRight(bool isPressed)
    {
        _playerMovement.SetDirectionY(isPressed);
    }
}
