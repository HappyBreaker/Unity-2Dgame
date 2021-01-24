using UnityEngine;


[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]

public class Boss : MonoBehaviour
{
    [Header("移動數值")]
    [Range(0f, 1000f)]
    public float MoveSpeed = 10.5f;
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
    private Player player;

    private void Start()
    {
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();

        player = FindObjectOfType<Player>();
        Rig.AddForce(transform.right);
    }

    void LateUpdate()
    {
        move();
    }

    private void move()
    {
        /*
        if(transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);
        
        float dis = Vector2.Distance(transform.position, player.postion);
        if (dis > RangeAtk)
        {
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * MoveSpeed);
        }
        else
        {
            attack();
        }

        Ani.SetBool("Walk", Rig.velocity.magnitude > 0);

        print(Rig.velocity.magnitude);

  
    }

    private void attack()
    {
        Rig.velocity = Vector3.zero;
        Ani.SetTrigger("Attack");
    }

    public void health(int Damage)
    {
        Health -= Damage;
        Ani.SetTrigger("GetHit");
    }
}
