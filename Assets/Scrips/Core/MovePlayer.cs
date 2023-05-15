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
    [SerializeField] Vector2 MousePos;

    
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

        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * Speed * Time.fixedDeltaTime);

        Vector2 Locdir = MousePos - Rigidbody.position;
        float angle = Mathf.Atan2(Locdir.y, Locdir.x) * Mathf.Rad2Deg ;
        Rigidbody.rotation = angle;
    }
}
