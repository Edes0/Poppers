using UnityEngine;

public class SoapController : MonoBehaviour
{
	public float pushForce = 5f;

	// Components
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();

		rb.gravityScale = 0;
		rb.freezeRotation = true;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();
			if (characterController != null && characterController.IsExpanding)
			{
				PushSoap(collision);
			}
		}
	}

	void PushSoap(Collision2D collision)
	{
		Vector2 pushDirection = GetDirection(transform.position - collision.transform.position);
		rb.linearVelocity = Vector2.zero; // Reset velocity before applying force
		rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
	}

	Vector2 GetDirection(Vector2 direction)
	{
		direction = direction.normalized;
		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			// Push horizontally
			return direction.x > 0 ? Vector2.right : Vector2.left;
		}
		else
		{
			// Push vertically
			return direction.y > 0 ? Vector2.up : Vector2.down;
		}
	}
}
