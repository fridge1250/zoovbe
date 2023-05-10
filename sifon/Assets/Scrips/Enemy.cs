using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private int speed = 5;
    //[SerializeField] private float Hearts = 5;
    public GameObject zoo;
    

    void Start()
    {
        player = GameObject.FindWithTag("Clay").GetComponent<zoombe_Clay>().player;
        zoo = GameObject.FindWithTag("Clay").GetComponent<zoombe_Clay>().zoo;

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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(zoo);
        }
    }
}
