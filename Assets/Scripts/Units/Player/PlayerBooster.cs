using System;
using UnityEngine;

public class PlayerBooster
{
    [Serializable]
    public class Settings
    {
        public float SpeedRate = 1.5f;
        public float MaxTime = 5f;
        public float RecoveryTime = 10f;
    }

    private bool _isPlaying = false;
    private bool _isOverload;
    private float _speedRate;
    private float _curTime;
    private float _maxTime;
    private float _recoveryTime;

    public PlayerBooster(Settings settings)
    {
        _speedRate = settings.SpeedRate;
        _maxTime = settings.MaxTime;
        _recoveryTime = settings.RecoveryTime;
    }

    public void OnUpdate()
    {
        if(_isOverload || _isPlaying == false)
        {
            if(_curTime <= 0) return;

            _curTime -= Time.deltaTime / _recoveryTime;
            if(_curTime <= 0)
            {
                Debug.Log("Booster recovery");
                _curTime = 0;
                _isOverload = false;
            }
        }
        else if(_isPlaying)
        {
            _curTime += Time.deltaTime / _maxTime;
            if(_curTime >= _maxTime)
            {
                // 부스터 과부하
                Debug.Log("Booster overload!!");
                _isOverload = true;
                _isPlaying = false;
            }
        }
    }

    public void Enable(bool enable)
    {
        if(_isOverload)
        {
            _isPlaying = false;
        }
        else
        {
            _isPlaying = enable;
        }
    }

    public float GetSpeedRate()
    {
        if(_isPlaying)
        {
            return _speedRate;
        }
        else
        {
            return 1;
        }
    }
}