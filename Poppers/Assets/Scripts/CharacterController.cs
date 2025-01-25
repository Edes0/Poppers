using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("MovementKeybinds")]
    [SerializeField] private KeyCode moveUpKey;
    [SerializeField] private KeyCode moveDownKey;
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(moveUpKey))
        {
            transform.localPosition += transform.up * Time.deltaTime * moveSpeed;
            Debug.Log("up");
        }
        if (Input.GetKey(moveDownKey))
        {

            transform.position += -transform.up * Time.deltaTime * moveSpeed;
            Debug.Log("Down");
        }
        if (Input.GetKey(moveLeftKey))
        {
            transform.localPosition += -transform.right * Time.deltaTime * moveSpeed;
            Debug.Log("Left");
        }
        if (Input.GetKey(moveRightKey))
        {
            transform.localPosition += transform.right * Time.deltaTime * moveSpeed;
            Debug.Log("Right");
        }
    }
}
