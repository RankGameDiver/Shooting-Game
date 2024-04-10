using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerAnimation
{
    private readonly SpriteResolver _spriteResolver;

    private int _curNum = 0;
    private const int _maxNum = 4;
    private float _curTime = 0;
    private float _animTime = 0.02f;

    private Action _animAction = null;

    public PlayerAnimation(SpriteResolver spriteResolver) 
    {
        _spriteResolver = spriteResolver;
        _animAction = () => OnFoward();
    }

    public void SetUpdateTime(float time) 
    {
        _animTime = time;
    }

    public void SetDirectionX(float directionX)
    {
        if(directionX > 0)
        {
            _animAction = () => OnRight();
        }
        else if(directionX < 0)
        {
            _animAction = () => OnLeft();
        }
        else
        {
            _animAction = () => OnFoward();
        }
    }

    public void OnUpdate() 
    {
        _curTime += Time.deltaTime / _animTime;
        if(_curTime >= _maxNum) 
        {
            _curTime = 0;
            if(_curNum >= _maxNum - 1) 
            {
                _curNum = 0;
            }
            else 
            {
                _curNum++;
            }

            _animAction.Invoke();
        }
    }

    public void OnFoward() 
    {
        _spriteResolver.SetCategoryAndLabel("Foward", _curNum.ToString());
    }

    public void OnLeft() 
    {
        _spriteResolver.SetCategoryAndLabel("Left", _curNum.ToString());
    }

    public void OnRight() 
    {
        _spriteResolver.SetCategoryAndLabel("Right", _curNum.ToString());
    }
}
