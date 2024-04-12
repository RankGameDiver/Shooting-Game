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
    private float _timePerFrame = 0.02f;
    private bool _isSetAnim = false;
    private Action _animCallback = null;

    public SpriteLibraryForAnimation(SpriteResolver spriteResolver, float timePerFrame)
    {
        _spriteResolver = spriteResolver;
        _timePerFrame = timePerFrame;
    }

    public void SetAnimation(string category, int maxNum, Action callback = null)
    {
        if(category == _curCategory)
        {
            return;
        }

        _curCategory = category;
        _curTime = 0;
        _curNum = 0;
        _maxNum = maxNum;
        _isSetAnim = true;

        _animCallback = callback;
        OnAction();
    }

    public void OnUpdate() 
    {
        if(!_isSetAnim)
        {
            return;
        }

        _curTime += Time.deltaTime / _timePerFrame;
        if(_curTime >= _maxNum) 
        {
            _curTime = 0;
            if(_curNum >= _maxNum - 1) 
            {
                _curNum = 0;
                if(_animCallback != null)
                {
                    _animCallback.Invoke();
                    _animCallback = null;
                }
            }
            else 
            {
                _curNum++;
            }
            OnAction();
        }
    }

    private void OnAction()
    {
        _spriteResolver.SetCategoryAndLabel(_curCategory, _curNum.ToString());
    }
}
