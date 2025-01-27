using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bubblePop;
    public AudioSource bubbleDamageBurst;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BubblePopSound()
    {
        bubblePop.Play();
    }
    public void BubbleDamageSound()
    {
        bubbleDamageBurst.Play();
    }

}
