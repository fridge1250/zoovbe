using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zoombe"))
        {
            Destroy(bullet);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
