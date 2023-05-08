using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] Vector2 Movement;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 MousePos;
    // здоровье игрока 
    [SerializeField] private int Numofhearts;
    [SerializeField] private float health;
    [SerializeField] Image[] hearts;
    [SerializeField] private Sprite Fullhearts;
    [SerializeField] private Sprite Emptyhearts;
    

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
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
        //health += Time.deltaTime * heart;
        Rigidbody.MovePosition(Rigidbody.position + Movement * Speed * Time.fixedDeltaTime);

        Vector2 Locdir = MousePos - Rigidbody.position;
        float angle = Mathf.Atan2(Locdir.y, Locdir.x) * Mathf.Rad2Deg ;
        Rigidbody.rotation = angle;
    }
}
