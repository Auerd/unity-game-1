using UnityEngine;
using static UnityEngine.KeyCode;

public class PlayerControl : MonoBehaviour
{
	public float speed;

	private Vector2 direction;

	public bool smooth_movement;

	private Rigidbody2D rb;

	public Animator animator;

    private void Start()
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
			if (Input.GetKey(D))
				direction.x = 1;
			else if (Input.GetKey(A))
				direction.x = -1;
			if (Input.GetKey(W))
				direction.y = 1;
			else if (Input.GetKey(S))
				direction.y = -1;
		}
		animator.SetFloat("Horizontal", direction.x);
		animator.SetFloat("Vertical", direction.y);
		if (direction.y != 0 || direction.x != 0)
		{
			animator.SetFloat("LastHorizontal", direction.x);
			animator.SetFloat("LastVertical", direction.y);
		}
		animator.SetFloat("Speed", direction.magnitude);
	}

	private void FixedUpdate()
	{
		if (direction.magnitude>1) direction.Normalize();
		rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
	}
}