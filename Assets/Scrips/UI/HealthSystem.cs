using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZombieTestProject.Core;
using System;

public class HealthSystem : MonoBehaviour
{
   private int _currentIndex = -1;

   private Image[] _healths;

   [SerializeField] private Image _healthPrefab;

   [SerializeField] private LayoutGroup _rootOfHealths;

   [SerializeField] private Sprite _emptyLive;

    private Player _player;

    [Inject]
    private void Init (Player player) => _player = player;

    private void Start() 
    {
        if (!_emptyLive) 
        {
            throw new NullReferenceException("sprite of empty live for health UI not seted");
        }

        _player.OnHit += RefreshStatus;

        _healths = new Image[_player.Health];

        for (int i = 0; i < _healths.Length; i++)
        {
            _healths[i] = Instantiate(_healthPrefab, _rootOfHealths.transform);
        }


    }

    private void RefreshStatus()
    {
        _currentIndex = Mathf.Clamp(_currentIndex + 1, 0, _healths.Length - 1);
        
        _healths[_currentIndex].sprite = _emptyLive;
    }

    private void OnDestroy() 
    {
        _player.OnHit -= RefreshStatus;
    }

    private void OnEnable() 
    {
        _player.OnHit += RefreshStatus;
    }

    private void OnDisable()
    {
        _player.OnHit -= RefreshStatus;
    }
}
