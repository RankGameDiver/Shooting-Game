using UnityEngine;

public class EnemyMovement : Movement
{
    private bool _isRight = false;
    private bool _isMoving = false;

    public EnemyMovement(float moveSpeed, GameObject moveObject) : base(moveSpeed, moveObject)
    {

    }

    public void SetDirectionX(GameObject objTarget)
    {
        float directionX = objTarget.transform.position.x - _moveObject.transform.position.x;
        // Debug.Log($"SetDirectionX. directionX : {directionX}");

        bool canRight = directionX > 0;
        bool canLeft = directionX < 0;
        if(!_isMoving)
        {
            if(canRight && directionX > _moveSpeed)
            {
                _isMoving = true;
                _isRight = true;
                SetDirectionX(_isRight);
            }
            else if(canLeft && directionX < -_moveSpeed)
            {
                _isMoving = true;
                _isRight = false;
                SetDirectionX(_isRight);
            }
        }
        else
        {
            if(canRight && !_isRight)
            {
                _isMoving = false;
                _isRight = !_isRight;
                SetDirectionX(_isRight);
            }
            else if(canLeft && _isRight)
            {
                _isMoving = false;
                _isRight = !_isRight;
                SetDirectionX(_isRight);
            }
        }
    }
}