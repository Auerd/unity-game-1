using System.Collections;
using UnityEngine;

public class CowControl : MonoBehaviour
{
	public Camera display;

	public float speed;

	public int seconds_end_move_randstart;
	public int seconds_end_move_end;

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
        topRight = display.ScreenToWorldPoint(new Vector2());
		bottomLeft = display.ScreenToWorldPoint(new Vector2(display.scaledPixelWidth, display.scaledPixelHeight));
		randomX = Random.Range(bottomLeft.x, topRight.x);
		randomY = Random.Range(bottomLeft.y, topRight.y);
		rb.position = (new Vector2(randomX, randomY));

		SetRandomForce();

		StartCoroutine(RandomForce());
	}

	// The cycle
	void Update()
	{
		rb.MovePosition(rb.position + force * Time.deltaTime);
		animator.SetFloat("RealSpeed", force.magnitude);
		animator.SetFloat("Horizontal", force.x);
		if (force.x > 0) spriteRenderer.flipX = false;
		else if (force.x < 0) spriteRenderer.flipX = true;
	}

	// Generates new force and manage the cycle
	IEnumerator RandomForce()
	{
		while (pause)
		{
			yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
														 seconds_end_move_end));
			force = new Vector2();

			yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
														 seconds_end_move_end));
			SetRandomForce();
		}
	}

    // Creates new force
    private void SetRandomForce()
	{
		randomX = Random.Range(bottomLeft.x, topRight.x);
		randomY = Random.Range(bottomLeft.y, topRight.y);
		force = new Vector2(randomX, randomY);
		force -= rb.position;
		force.Normalize();
		force *= speed;
	}
}
