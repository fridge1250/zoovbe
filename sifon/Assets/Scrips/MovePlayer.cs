using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] Vector2 Movement;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 MousePos;

    //[SerializeField] private float hp = 10;
    // здоровье игрока 
    /*
    [SerializeField] private int Numofhearts;
    [SerializeField] private float health;
    [SerializeField] Image[] hearts;
    [SerializeField] private Sprite Fullhearts;
    [SerializeField] private Sprite Emptyhearts;
    */
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "zoombe")
        {
            HeartsSystem.health--;
            if(HeartsSystem.health < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("zoombe"))
        {
            hp -= 1f * Time.deltaTime;
        }
        if(hp == 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }
    */
    void FixedUpdate()
    {
        /*
        if(health > Numofhearts)
        {
            health = Numofhearts;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = Fullhearts;
            }
            else
            {
                hearts[i].sprite = Emptyhearts;
            }
            if(i < Numofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        */
        
        //health += Time.deltaTime * heart;
        Rigidbody.MovePosition(Rigidbody.position + Movement * Speed * Time.fixedDeltaTime);

        Vector2 Locdir = MousePos - Rigidbody.position;
        float angle = Mathf.Atan2(Locdir.y, Locdir.x) * Mathf.Rad2Deg ;
        Rigidbody.rotation = angle;
    }
}
