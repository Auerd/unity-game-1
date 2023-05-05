using System.Collections;
using UnityEngine;

public class CowControl : MonoBehaviour
{
    public Camera display;

    public float speed;

    public int secondsToMoveRangeStart;
    public int secondsToMoveRangeEnd;

    private Vector2 force;
    private Vector2 topRight;
    private Vector2 bottomLeft;
    private float randomX;
    private float randomY;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool pause;


    void Start()
    {
        pause = true;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Sets random position on start of the scene
        rb.position = GetRandomPointFromDisplay(display);

        SetRandomForce();

        StartCoroutine(ForceControl());
    }

    void Update()
    {
        animator.SetBool("IsMoving", force.magnitude != 0);

        if (force.x > 0) spriteRenderer.flipX = false;
        else if (force.x < 0) spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + force * Time.fixedDeltaTime);
    }

    IEnumerator ForceControl()
    {
        while (pause)
        {
            yield return new WaitForSeconds(Random.Range(secondsToMoveRangeStart,
                                                         secondsToMoveRangeEnd));
            force = new Vector2();

            yield return new WaitForSeconds(Random.Range(secondsToMoveRangeStart,
                                                         secondsToMoveRangeEnd));
            SetRandomForce();
        }
    }

    private void SetRandomForce()
    {
        force = GetRandomPointFromDisplay(display);
        force -= rb.position;
        force.Normalize();
        force *= speed;
    }

    private Vector2 GetRandomPointFromDisplay(Camera display)
    {
        topRight = display.ScreenToWorldPoint(new Vector2());
        bottomLeft = display.ScreenToWorldPoint(new Vector2(display.scaledPixelWidth, display.scaledPixelHeight));
        randomX = Random.Range(bottomLeft.x, topRight.x);
        randomY = Random.Range(bottomLeft.y, topRight.y);
        return new Vector2(randomX, randomY);
    }
}
