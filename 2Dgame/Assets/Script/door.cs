using UnityEngine;

public class door : MonoBehaviour
{

    [Header("Key")]
    public GameObject Key;
    public AudioClip DoorSound;

    private Animator Ani;
    private AudioSource Aud;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && Key == null)
        {
            Ani.SetTrigger("key");
            Aud.PlayOneShot(DoorSound, Random.Range(1f, 1.5f));
        }
    }




}
