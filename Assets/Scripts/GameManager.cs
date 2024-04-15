using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Serializable]
    public class Settings 
    {
        public GameObject ObjPlayer;
        public GameObject ObjEnemy;

        public Vector3 PlayerStartPos;
        public Vector3 EnemyStartPos;
    }

    private PlayerFacade _player;
    private EnemyFacade _enemy;
    private PlayerHeartController _playerHeartController;

    [SerializeField] private Settings _settings;

    void Awake()
    {
        _playerHeartController = FindObjectOfType<PlayerHeartController>();
        _player = Instantiate(_settings.ObjPlayer, _settings.PlayerStartPos, Quaternion.identity, transform).GetComponent<PlayerFacade>();
        _player.SetHeartController(_playerHeartController);
        _enemy =  Instantiate(_settings.ObjEnemy, _settings.EnemyStartPos, Quaternion.identity, transform).GetComponent<EnemyFacade>();
    }
}