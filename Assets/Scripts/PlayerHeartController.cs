using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartController : MonoBehaviour
{
    [SerializeField] private GameObject _objHeart;
    private List<Heart> _hearts = new List<Heart>();

    private int _curCount;
    private int _maxCount;

    public void Init(int heartAmount)
    {
        _curCount = heartAmount;
        _maxCount = heartAmount;
        for(int i = 0; i < heartAmount; i++)
        {
            _hearts.Add(Instantiate(_objHeart, transform).GetComponent<Heart>());
        }
    }

    public void Increase()
    {
        if(_curCount >= _maxCount)
        {
            return;
        }

        _hearts[_curCount].Enable(true);
        _curCount++;
    }

    public void Decrease()
    {
        if(_curCount <= 0)
        {
            return;
        }

        _hearts[_curCount - 1].Enable(false);
        _curCount--;
    }
}