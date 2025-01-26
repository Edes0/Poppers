using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[Header("MovementKeybinds")]
	[SerializeField] private KeyCode moveUpKey;
	[SerializeField] private KeyCode moveDownKey;
	[SerializeField] private KeyCode moveLeftKey;
	[SerializeField] private KeyCode moveRightKey;
	[SerializeField] private KeyCode expandKey;

	[Header("Settings")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float originalMoveSpeed;
	[SerializeField] private float expandScale;
	[SerializeField] private float minLethalVelocity = 5f;
	[SerializeField] private float maxPushForce;
	//[SerializeField] private float delayBeforeDeflate; // Used for fixed delay for deflate. now used with dynamic on held down

	public Vector3 ogTransformScale;
	[SerializeField] public float decelerationRate;
	public bool IsExpanding = false;
	public bool IsShrinking = false;
	private float ExpandActualCooldown;
	public float ExpandCooldownDelay;
	private float ExpandTimeHeldDown;
	public float PushForce;
	public float chargeMovespeedDecay;
	// Components
	private Rigidbody2D rb;
	private CircleCollider2D circleCollider;
	private GameObject player;

	void Awake()
	{
		originalMoveSpeed = moveSpeed;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();

		rb.gravityScale = 0;
		rb.freezeRotation = true;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		ogTransformScale = transform.localScale;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		SlowDown();
		if (ExpandActualCooldown > 0)
		{

		}

		if (Input.GetKey(moveUpKey))
		{
			transform.localPosition += transform.up * Time.deltaTime * moveSpeed;
			//Debug.Log("up");
		}
		if (Input.GetKey(moveDownKey))
		{
			transform.position += -transform.up * Time.deltaTime * moveSpeed;
			//Debug.Log("Down");
		}
		if (Input.GetKey(moveLeftKey))
		{
			transform.localPosition += -transform.right * Time.deltaTime * moveSpeed;
			//Debug.Log("Left");
		}
		if (Input.GetKey(moveRightKey))
		{
			transform.localPosition += transform.right * Time.deltaTime * moveSpeed;
			//Debug.Log("Right");
		}
		if (Input.GetKey(expandKey) && ExpandActualCooldown <= 0)
		{
			IsShrinking = true;
			Debug.Log($"{gameObject.name} is Shrinking");
			// Slow down movement speed gradually
			if (moveSpeed > 0.7f)
			{
				moveSpeed *= chargeMovespeedDecay;
			}

			// Increase the time the key is held down (up to a limit)
			if (ExpandTimeHeldDown < 3f)
			{
				ExpandTimeHeldDown += 0.1f;
			}

			if (PushForce < maxPushForce)
			{
				PushForce += 0.1f;
			}

		}
		if (!Input.GetKey(expandKey) && IsShrinking)
		{
			IsShrinking = false;
			Debug.Log($"{gameObject.name} is Expanding");
			IsExpanding = true;

			ExpandActualCooldown += ExpandCooldownDelay;
			transform.localScale = new Vector3(expandScale, expandScale, expandScale);

			StartCoroutine(Deflate(ogTransformScale));
			StartCoroutine(CooldownTimer());

			// Reset movement speed
			moveSpeed = originalMoveSpeed;
		}

	}

	private IEnumerator CooldownTimer()
	{
		while (ExpandActualCooldown > 0)
		{
			yield return new WaitForSeconds(ExpandCooldownDelay);
			ExpandActualCooldown -= ExpandCooldownDelay;
		}
	}

	//void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (collision.gameObject.CompareTag("Soap"))
	//	{
	//		Debug.Log($"{gameObject.name} collided with {collision.gameObject.name} with volocity");

	//		SoapController soapController = collision.gameObject.GetComponent<SoapController>();
	//		if (!IsExpanding && soapController.IsMoving)
	//		{
	//			Debug.Log("Death");
	//			GameManager.instance.PlayerDeath(gameObject.name);
	//		}
	//	}
	//}

	void OnCollisionEnter2D(Collision2D collision)
	{
		float collisionVelocity = collision.relativeVelocity.magnitude;
		Debug.Log($"{gameObject.name} collided with {collision.gameObject.name} with velocity: {collisionVelocity}");

		if (!IsExpanding && collisionVelocity >= minLethalVelocity)
		{
			Debug.Log($"Death due to high velocity collision: {collisionVelocity}");
			GameManager.instance.PlayerDeath(gameObject.name);
		}
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

	IEnumerator Deflate(Vector3 ogScale)
	{
		if (ExpandTimeHeldDown < 0.2f)
		{
			ExpandTimeHeldDown = 0.2f;
		}

		yield return new WaitForSeconds(ExpandTimeHeldDown / 3);
		transform.localScale = ogScale;
		Debug.Log("Deflated");
		Debug.Log($"Was expanded for {ExpandTimeHeldDown / 3} sec");
		IsExpanding = false;
		ExpandTimeHeldDown = 0f;
		PushForce = 0f;
	}
}