using UnityEngine;


[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]

public class Boss : MonoBehaviour
{
    [Header("移動數值")]
    [Range(0f, 1000f)]
    public float MoveSpead = 10.5f;
    [Header("攻擊範圍")]
    [Range(0, 1000)]
    public int RangeAtk = 100;
    [Header("傷害")]
    [Range(0, 200)]
    public int Attack = 20;
    [Header("血量")]
    [Range(0, 200)]
    public int Health = 100;


    [Header("音效")]
    public AudioClip Sound;

    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;

    private void Start()
    {
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();        
    }

    void Update()
    {

    }

    private void move()
    {

    }

    private void attack()
    {
        
    }

    public void health(int Damage)
    {
        Health -= Damage;
        Ani.SetTrigger("GetHit");
    }
}
