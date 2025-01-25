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
	[SerializeField] private float expandScale;
	[SerializeField] private float delayBeforeDeflate;

	public Vector3 ogTransformScale;
	public float decelerationRate = 0.95f;
	public bool IsExpanding = false;

	// Components
	private Rigidbody2D rb;
	private CircleCollider2D circleCollider;
	private GameObject player;

	void Awake()
	{
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
		if (Input.GetKey(expandKey) && !IsExpanding)
		{
			Debug.Log("Expanding");
			IsExpanding = true;
			transform.localScale = new Vector3(expandScale, expandScale, expandScale);
			StartCoroutine(Deflate(ogTransformScale));
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Soap"))
		{
			Debug.Log($"Collision with soap");

			SoapController soapController = collision.gameObject.GetComponent<SoapController>();
			if (!IsExpanding && soapController.IsMoving)
			{
				Debug.Log($"Die");
				// Player Death
				// GameManager.PlayerDeath(gameObject.PlayerName)
			}
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
		yield return new WaitForSeconds(delayBeforeDeflate);
		transform.localScale = ogScale;
		Debug.Log("Deflated");
		IsExpanding = false;
	}
}