using UnityEngine;

public class SoapController : MonoBehaviour
{
	public float pushForce = 5f;
	public float decelerationRate = 0.95f;
	public bool IsMoving = false;

	// Components
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();

		rb.gravityScale = 0;
		//rb.freezeRotation = true; Rotation for soaps
	}

	void Start()
    {
    }

	void FixedUpdate()
	{
		SlowDown();

		if (transform.hasChanged)
		{
			transform.hasChanged = false;
		}
		else
		{
			IsMoving = false;
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			CharacterController playerController = collision.gameObject.GetComponent<CharacterController>();
			if (playerController != null && playerController.IsExpanding)
			{
				PushSoap(collision);
			}
		}
	}

	// Soap stuck on other Soap
	//void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (collision.gameObject.CompareTag("Soap"))
	//	{
	//		Rigidbody2D rb = GetComponent<Rigidbody2D>();
	//		if (rb != null)
	//		{
	//			rb.linearVelocity = Vector2.zero;
	//		}
	//	}
	//}

	void PushSoap(Collision2D collision)
	{
		Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
		rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

		// for x and y movement
		//Vector2 pushDirection = GetDirection(transform.position - collision.transform.position);
		//rb.linearVelocity = Vector2.zero; // Reset velocity before applying force
		//rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
		IsMoving = true;
		//Debug.Log("Soap is pushed");
	}

	void SlowDown()
	{
		// Gradually reduce velocity
		rb.linearVelocity *= decelerationRate;

		// Stop completely if moving very slowly
		if (rb.linearVelocity.magnitude < 0.01f)
		{
			rb.linearVelocity = Vector2.zero;
		}
	}

	// For x and y movement only
	//Vector2 GetDirection(Vector2 direction)
	//{
	//	direction = direction.normalized;
	//	if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
	//	{
	//		// Push horizontally
	//		return direction.x > 0 ? Vector2.right : Vector2.left;
	//	}
	//	else
	//	{
	//		// Push vertically
	//		return direction.y > 0 ? Vector2.up : Vector2.down;
	//	}
	//}
}
