using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] Vector2 Movement;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 MousePos;

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * Speed * Time.fixedDeltaTime);

        Vector2 Locdir = MousePos - Rigidbody.position;
        float angle = Mathf.Atan2(Locdir.y, Locdir.x) * Mathf.Rad2Deg - 90f;
        Rigidbody.rotation = angle;
    }
}
