using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteLibraryForAnimation
{
    private readonly SpriteResolver _spriteResolver;

    private string _curCategory;
    private int _curNum = 0;
    private int _maxNum = 4;
    private float _curTime = 0;
    private float _animTime = 0.02f;

    private Action _animAction = null;

    public SpriteLibraryForAnimation(SpriteResolver spriteResolver, float time)
    {
        _spriteResolver = spriteResolver;
        _animTime = time;
    }

    public void SetAnimation(string category, int maxNum)
    {
        _curCategory = category;
        _curNum = 0;
        _maxNum = maxNum;

        _animAction = () => OnAction();
    }

    public void OnUpdate() 
    {
        if(_animAction == null)
        {
            return;
        }

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

    private void OnAction()
    {
        _spriteResolver.SetCategoryAndLabel(_curCategory, _curNum.ToString());
    }
}
