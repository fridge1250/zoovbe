namespace ZombieTestProject.Core
{
using UnityEngine;
using System;
public abstract class Enemy : MonoBehaviour
{
    private Player _player;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 movement;
    [SerializeField] private int speed = 5;
    

    private void Start()
    {
        if (!TryGetComponent(out _rigidbody)) 
        {
            throw new NullReferenceException("enemy must have component Rigidbody2D");
        }

        _player = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        if (_player && Vector2.Distance(_player.transform.position, transform.position) > 1f) 
        {
            Vector2 playerPosition = _player.transform.position;
        Vector3 direction = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        Move(movement);
        _rigidbody.rotation = angle;
        }

        // rotating
    }
    private void Move(Vector2 direction)
    {
        _rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }
}

}
