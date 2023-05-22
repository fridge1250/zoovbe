using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZombieTestProject.Core;
using System;
using ZombieTestProject.SO;
using ZombieTestProject.Interfaces;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class MovePlayer : MonoBehaviour
{
    private PlayerData _data;
    private Rigidbody2D _body;
    private Vector2 _movement;
    private Vector2 _mousePosition;

    private void Start() 
    {
        if (!TryGetComponent(out _body))
        {
            throw new NullReferenceException("player movement component must have Rigidbody2D component");
        }
        if (!TryGetComponent(out IPlayer player)) 
        {
            throw new NullReferenceException("movement player component must have component Player");
        }

        _data = player.Data;
    }

    private void Update()
    {
        _movement.x = GetAxisRaw("Horizontal");

        _movement.y = GetAxisRaw("Vertical");

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Move();

        Rotate();
    }

    private void Move()
    {
        _body.MovePosition(_body.position + _movement * _data.Speed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Vector2 direction = _mousePosition - _body.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _body.rotation = angle;
    }

    private float GetAxisRaw (string axisName) 
    {
        if (string.IsNullOrEmpty(axisName))
        {
            throw new ArgumentNullException("axis name is null or empty");
        }

        return Input.GetAxisRaw(axisName);
    }
}
