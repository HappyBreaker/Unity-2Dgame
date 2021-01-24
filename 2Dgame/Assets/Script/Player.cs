﻿using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    #region [練習欄位]
    [Header("移動數值")]
    [Range(0f,1000f)]
    public float MoveSpead = 10.5f;
    [Header("跳越高度")]
    [Range(0, 1000)]
    public int JumpHeight = 100;
    [Header("是否在地上")]
    [Tooltip("是否在地上")]
    public bool OnTheGround = true;
    [Header("子彈-物件")]
    [Tooltip("子彈-物件")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    [Tooltip("子彈生成點")]
    public Transform BulletPosition;
    [Header("子彈速度")]
    [Tooltip("子彈速度")]
    [Range(0, 5000)]
    public float BulletSpeed = 500;
    [Header("子彈傷害")]
    [Tooltip("子彈傷害")]
    [Range(0, 5000)]
    public float BulletDamage = 50;
    [Header("開槍音效")]
    [Tooltip("開槍音效")]
    public AudioClip Sound;
    [Header("血量")]
    [Tooltip("血量")]
    [Range(0,200)]
    public int Health = 100;
    [Header("血量文字")]
    public Text TextHp;
    [Header("血量圖片")]
    public Image ImgHp;
    [Header("碰撞位置")]
    public Vector3 postion ;
    [Header("碰撞半徑")]
    public float range;



    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    #endregion


    private void Start()
    {
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }


    public float x;

    public void Update()
    {
        GetHorizontal();
        move();
        jump();
        fire();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.4f);
        Gizmos.DrawSphere(transform.position + postion, range);
    }

    [Header("開門音效")]
    public AudioClip KeySound;

    //處發事件：Enter
    private void OnTriggerEnter2D(Collider2D other)
    {
        //當碰到Tag(Key)的物件時執行
        if(other.tag =="Key")
        {
            Destroy(other.gameObject);
            Aud.PlayOneShot(KeySound, Random.Range(1f, 1.5f));
        }
    }

    private void GetHorizontal()
    {
        x = Input.GetAxis("Horizontal");
    }

    private void move()
    {
        Rig.velocity = new Vector2(x * MoveSpead, Rig.velocity.y);

        if(Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.RightArrow))
            {
            transform.localEulerAngles = Vector3.zero;
            }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            }

        Ani.SetBool("run", x != 0);
    }

    private void jump()
    {
        if(OnTheGround == true && Input.GetKeyDown(KeyCode.Space))
            {
            Rig.AddForce(new Vector2(0, JumpHeight));
            Ani.SetTrigger("jumping");
            }

        Collider2D hit = Physics2D.OverlapCircle(transform.position + postion, range, 1 << 8);
        
        if(hit)
        {
            OnTheGround = true;
        }
        else
        {
            OnTheGround = false;
        }

        Ani.SetFloat("jump", Rig.velocity.y);
        Ani.SetBool("on the ground", OnTheGround);
    }

    private void fire()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Aud.PlayOneShot(Sound, Random.Range(1f, 1.5f));
            GameObject temp = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);

            temp.GetComponent<Rigidbody2D>().AddForce(BulletPosition.right * BulletSpeed + BulletPosition.up * 100);

            temp.AddComponent<Bullet>().Damage = BulletDamage;
        }
    }

    private void Dead()
    {
        Health = 0;
        TextHp.text = Health.ToString();
        Ani.SetBool("Die",true);
        enabled = false;
    }

    /*public void test()
    {
        Debug.Log("Hello World");//Debug.Log
        print("Hello World");//print
    }

    public int n1()
    {
        return 10;
    }

    public string Name()
    {
        return "HappyBreaker";
    }
    
    public void test2(string MyName)
    {
        //MyName = Name();
        print(MyName);
    }

    private void Drive(string Sound, int Speed, string direction = "sda")
    {
        print("開車方向：" + direction);
        print("開車音效：" + Sound);
        print("開車速度：" + Speed);

    }

    private void test3(int speed = 50)
    {
        print("開雨刷");
        print("雨刷速度" + speed);
    }
    
    private void Start()
    {
        print("n1的傳回值:" + n1());
        
        test2("HappyBaker");
        test();
        
        Drive("前方",100, "噗噗噗");
        Drive("後方", 75, "哈哈哈");
        Drive("左方", 50, "滴滴滴");
        Drive("右方", 25);

        test3();
        test3(75);
        
    }
   */
    

}
