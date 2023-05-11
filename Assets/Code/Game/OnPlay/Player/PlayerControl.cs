using UnityEngine;
using static UnityEngine.Input;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
	[SerializeField]
	private float speed;

	private Vector2 direction;

	[SerializeField]
	private bool smooth_movement;

	private Rigidbody2D rb;

	[SerializeField]
	private Animator animator;

	private void Start()=>
		rb = GetComponent<Rigidbody2D>();

	void Update()
	{
		if (smooth_movement)
		{
			direction.x = GetAxis("Horizontal");
			direction.y = GetAxis("Vertical");
		}
		else
		{
			direction.x = GetAxisRaw("Horizontal");
			direction.y = GetAxisRaw("Vertical");
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
		if (direction.magnitude > 1) direction.Normalize();
		rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
	}
}