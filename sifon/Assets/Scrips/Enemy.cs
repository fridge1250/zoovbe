using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private int speed = 5;
    //[SerializeField] private float Hearts = 5;
    [SerializeField] private GameObject zoo;

    void Start()
    {
        

        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        MoveChar(movement);
    }
    private void MoveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(zoo);
        }
        
        
    }
    
}
