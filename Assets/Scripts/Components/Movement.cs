using UnityEngine;

public class Movement
{
    private Vector3 _direction = Vector2.zero;
    protected float _moveSpeed;
    protected float _curMoveSpeed;
    protected GameObject _moveObject;

    public Movement(float moveSpeed, GameObject moveObject)
    {
        _moveSpeed = moveSpeed;
        _curMoveSpeed = _moveSpeed;
        _moveObject = moveObject;
    }

    // 좌 우 방향 설정
    public void SetDirectionX(bool isRight)
    {
        _direction.x = isRight ? _direction.x + 1 : _direction.x - 1;
    }
    
    // 위 아래 방향 설정
    public void SetDirectionY(bool isForward)
    {
        _direction.y = isForward ? _direction.y + 1 : _direction.y - 1;
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }

    // 매 프레임마다 호출되어야 하는 함수
    public void OnUpdate(float speedRate = 1)
    {
        _curMoveSpeed = _moveSpeed * speedRate;
        _moveObject.transform.position += _curMoveSpeed * _direction;
    }
}
