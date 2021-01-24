using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]

public class Boss : MonoBehaviour
{
    [Header("移動數值")]
    [Range(0f, 100f)]
    public float MoveSpeed = 10.5f;
    [Header("攻擊範圍")]
    [Range(0f, 100f)]
    public float RangeAtk;
    [Header("攻擊CD")]
    [Range(0f, 100f)]
    public float CDAtk;
    [Header("傷害")]
    [Range(0, 200)]
    public int Attack = 20;
    [Header("血量")]
    [Range(0, 2000)]
    public float Health = 2000f;
    [Header("血量文字")]
    public Text TextHp;
    [Header("血量圖片")]
    public Image ImgHp;


    [Header("音效")]
    public AudioClip Sound;

    [Header("攻擊範圍位移")]
    public Vector3 OffSetAtk;
    [Header("攻擊判定範圍")]
    public Vector3 SizeAtk;

    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    private float HealthMax;
    private Player player;
    private float Timer;

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
        if (Ani.GetBool("BossDead", false));
        move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * OffSetAtk.x + transform.up * OffSetAtk.y, SizeAtk);
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
        if(Timer < CDAtk)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Ani.SetTrigger("Attack");
            Timer = 0;
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * OffSetAtk.x + transform.up * OffSetAtk.y, SizeAtk, 0, 1 << 9);
            print(hit.name);
        }
    }

    public void health(float Damage)
    {
        Health -= Damage;
        TextHp.text = Health.ToString();
        ImgHp.fillAmount = Health / HealthMax;

        if (Health <= 0) Dead();
        Ani.SetTrigger("GetHit");
    }

    private void Dead()
    {
        Health = 0;
        TextHp.text = 0.ToString();
        Ani.SetBool("BossDead", true);

        GetComponent<CapsuleCollider2D>().enabled = false;
        Rig.Sleep();
    }
}
