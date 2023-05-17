namespace ZombieTestProject.Core
{
using System.Collections;
using UnityEngine;
using Zenject;
using ZombieTestProject.Core.Enemies;

    [RequireComponent(typeof(Zombie))]
    public class ZombieCombat : MonoBehaviour 
    {
        private Player _player;

        private Coroutine _currentCoroutine;

        [Inject]
    private void Init (Player player) => _player = player;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent(out Player _)) 
            {
                if (_currentCoroutine != null) 
                {
                    StopCoroutine(_currentCoroutine);
                }

                _currentCoroutine = StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack () 
        {
            while (true) 
            {
                _player?.Hit(1);

                yield return new WaitForSeconds(1f); 

            }
        }
    }
}