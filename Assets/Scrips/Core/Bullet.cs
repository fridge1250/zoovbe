namespace ZombieTestProject.Core
{
using UnityEngine;
using System;
using ZombieTestProject.Interfaces;

    [RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IBullet
{
     private Rigidbody2D _body;

    [SerializeField, Min(1f)] private float _force = 20f;

    [SerializeField, Min(1)] private int _damage = 1;

        public float Force => _force;
        public int Damage => _damage;

        private void OnEnable ()
        {

            if (!_body)
            {

                if (!TryGetComponent(out _body))
                {
                    throw new NullReferenceException("Rigidbody2D not seted on bullet");
                }

            }
        }

        public void Activate()
        {
            _body.velocity = Vector2.zero;

            _body.AddForce(transform.up * _force, ForceMode2D.Impulse);
        }

        private void Update() 
        {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height) 
       {

    gameObject.SetActive(false);
       }

       }

        public void SetRotation(Quaternion quaternion)
        {
            transform.rotation = quaternion;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }

}