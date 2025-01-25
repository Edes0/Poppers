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
	private GameObject player;
	[Header("Settings")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float expandScale;
	[SerializeField] private float delayBeforeDeflate;

	public Vector3 ogTransformScale;

	private bool IsExpanding = false;


	// Components
	private Rigidbody2D rb;
	private CircleCollider2D circleCollider;

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

	//void Update()
	//{
	//	if (transform.localScale == ogTransformScale)
	//	{
	//		IsExpanding = false;
	//	}
	//}

	// Update is called once per frame
	void FixedUpdate()
	{
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

			if (IsExpanding)
			{
				Debug.Log($"Push soap");
				// Push soap
			}
			else
			{
			    //if (collision.gameObject.IsMoving)
				//{
			     Debug.Log($"Die");
				//	//Player Death
				//	//GameManager.PlayerDeath(gameObject.PlayerName)
				//}
			}
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