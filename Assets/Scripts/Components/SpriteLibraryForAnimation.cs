using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

/// <summary>
/// Sprite 이미지 애니메이션 연출 코드
/// </summary>
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

    // 애니메이션 초기 설정(category : 애니메이션 이름, maxNum : 총 이미지 개수, callback : 애니메이션 종료 후 실행할 동작)
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

    // 매 프레임마다 호출되어야 하는 함수
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

    // 다음 이미지로 넘어가는 함수
    private void OnAction()
    {
        _spriteResolver.SetCategoryAndLabel(_curCategory, _curNum.ToString());
    }
}
