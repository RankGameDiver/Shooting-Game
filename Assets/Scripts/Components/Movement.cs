using UnityEngine;

public class Movement
{
    private Vector3 _direction = Vector2.zero;
    protected float _moveSpeed;
    protected GameObject _moveObject;

    public Movement(float moveSpeed, GameObject moveObject)
    {
        _moveSpeed = moveSpeed;
        _moveObject = moveObject;
    }

    public void SetDirectionX(bool isRight)
    {
        _direction.x = isRight ? _direction.x + 1 : _direction.x - 1;
    }
    
    public void SetDirectionY(bool isForward)
    {
        _direction.y = isForward ? _direction.y + 1 : _direction.y - 1;
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }

    public void OnUpdate()
    {
        _moveObject.transform.position += _moveSpeed * _direction;
    }
}
