using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CowControl : MonoBehaviour
{
    public Camera display;

    public float speed;

    public int seconds_end_move_randstart;
    public int seconds_end_move_end;

    private Vector2 force;

    private Rigidbody2D rb;
    private Animator animator;

    private bool pause;

    void Start()
    {
        pause = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Sets random position and force
        rb.position = new Vector2(Random.Range(-display.pixelWidth / 2, display.pixelWidth / 2),
                                  Random.Range(-display.pixelHeight / 2, display.pixelHeight / 2));
        force = new Vector2(Random.Range(-100f, 100f) / 100,
                            Random.Range(-100f, 100f) / 100);
        force.Normalize();

        StartCoroutine(RandomForce());
    }

    // The cycle
    void Update()
    {
        rb.MovePosition(rb.position + force * speed);
        animator.SetFloat("Speed", force.magnitude);
        animator.SetFloat("Horizontal", force.x);
        if (force.x > 0) animator.SetFloat("LastHor", force.x);
        else if (force.x <= 0) animator.SetFloat("LastHor", force.x);
    }

// Generates new force and manage the cycle
IEnumerator RandomForce()
    {
        while (pause)
        {
            yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
                                                         seconds_end_move_end));
            force = new Vector2(Random.Range(-display.pixelWidth / 2, display.pixelWidth / 2),
                    Random.Range(-display.pixelHeight / 2, display.pixelHeight / 2));
            force -= rb.position;
            force.Normalize();

            yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
                                                         seconds_end_move_end));
            force = new Vector2();

            // Creates new force

        }
    }
}
