using UnityEngine;
using static System.Math;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public float speed;

    private Vector2 move;
    private Vector2 direction;

    public bool smooth_movement;
    
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (smooth_movement)
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
        else
        {
            direction.x = 0;
            direction.y = 0;
            if (Input.GetKey("d"))
                direction.x = 1;
            else if (Input.GetKey("a"))
                direction.x = -1;
            if (Input.GetKey("w"))
                direction.y = 1;
            else if (Input.GetKey("s"))
                direction.y = -1;
        }
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        if (direction.y != 0 || direction.x != 0)
        {
            animator.SetFloat("Last_Horizontal", direction.x);
            animator.SetFloat("Last_Vertical", direction.y);
        }
        animator.SetFloat("Speed", direction.magnitude);
    }

    private void FixedUpdate()
    {
        if (Sqrt(direction.x * direction.x + direction.y * direction.y)>1)
        direction.Normalize();
        move = speed * Time.fixedDeltaTime * direction;
        rb.MovePosition(rb.position + move);
    }
}