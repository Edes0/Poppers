using UnityEngine;

public class AnimationState : MonoBehaviour
{
   public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsPlayer1Charging", true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsPlayer1Charging", false);
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsPlayer2Charging", true);
        }
        
        if (!Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsPlayer2Charging", false);
        }
    }
}