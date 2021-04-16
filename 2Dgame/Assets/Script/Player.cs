using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour
{
    #region [練習欄位]
    [Header("移動數值"), Range(0f, 1000f)]
    public float MoveSpead = 10.5f;
    [Header("跳越高度"), Range(0, 1000)]
    public int JumpHeight = 100;
    [Header("是否在地上"), Tooltip("是否在地上")]
    public bool OnTheGround = true;
    // [Header("子彈-物件"), Tooltip("子彈-物件")]
    //public GameObject Bullet;
    //[Header("子彈生成點"), Tooltip("子彈生成點")]
    //public Transform BulletPosition;
    //[Header("子彈速度"), Tooltip("子彈速度"), Range(0, 5000)]
    //public float BulletSpeed = 500;
    //[Header("子彈傷害"), Tooltip("子彈傷害"), Range(0, 5000)]
    //public float BulletDamage = 50;
    [Header("地板碰撞位置")]
    public Vector3 postion;
    [Header("地板碰撞半徑")]
    public float range;

    [Header("血量"), Tooltip("血量"), Range(0, 200)]
    public float Health = 200;
    [Header("血量文字")]
    public Text TextHp;
    [Header("血量圖片")]
    public Image ImgHp;
    [Header("結束面板")]
    public GameObject EndPanel;

    [Header("攻擊判定點")]
    public Vector3 attackPoint;
    [Header("攻擊判定範圍")]
    public Vector3 attackRange;
    [Header("攻擊判定時間點"), Range(0, 10f)]
    public float attackTime;
    [Header("攻擊CD"), Range(0, 10f)]
    public float attackCD;
    [Header("攻擊傷害"), Range(0, 100f)]
    public float attackDamage = 50;
    [Header("攻擊音效"), Tooltip("音效")]
    public AudioClip atkSound;
    [Header("膽怯移動"), Range(0f, 1000f)]
    public float backSpead = 20.5f;

    private float timer;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    private SpriteRenderer Spr;
    private float HealthMax;

    public Boss boss;
    //private CamerControl Cam;
    #endregion


    private void Start()
    {
        Aud = GetComponent<AudioSource>();      //取得<音效>元件
        Rig = GetComponent<Rigidbody2D>();      //取得<剛體2D>元件
        Ani = GetComponent<Animator>();         //取得<動畫>元件
        Spr = GetComponent<SpriteRenderer>();   //取得<繪圖>元件

        HealthMax = Health;                     //初始化設定血量
        TextHp.text = Health.ToString();
        ImgHp.fillAmount = Health / HealthMax;  //連接同步血條

    }


    private float x;

    public void Update()
    {
        GetHorizontal();    //待命子程序"GetHorizontal"
        move();             //待命子程序"move"
        jump();             //待命子程序"jume"
        Attack();           //待命子程序"Attack"

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.4f);
        Gizmos.DrawSphere(transform.position + postion, range);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * attackPoint.x + transform.up * attackPoint.y, attackRange);
    }

    private void GetHorizontal()
    {
        x = Input.GetAxis("Horizontal"); //將水平輸入至變數"x"
    }

    private void move()
    {
        Rig.velocity = new Vector2(x * MoveSpead, Rig.velocity.y); // 移動量(X * 設定速度,固定高度)

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.D) == false) //根據方向鍵改變面相的角度
        {
            transform.localEulerAngles = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A) == false)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        Ani.SetBool("run", x != 0); //當開始移動時撥放"移動"動畫
    }

    private void jump()
    {
        if (OnTheGround == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rig.AddForce(new Vector2(0, JumpHeight));
            Ani.SetTrigger("jumping");
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position + postion, range, 1 << 8);

        if (hit)
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

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timer >= attackCD)
        {
            Ani.SetTrigger("attack1");
            Aud.PlayOneShot(atkSound);
            timer = 0;
            StartCoroutine(AttackDelay());
        }
        else
        {
            timer += Time.deltaTime;
        }

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            Aud.PlayOneShot(Sound, Random.Range(1f, 1.5f));
            GameObject temp = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);

            temp.GetComponent<Rigidbody2D>().AddForce(BulletPosition.right * BulletSpeed + BulletPosition.up * 100);

            temp.AddComponent<Bullet>().Damage = BulletDamage;
        }*/
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackTime);
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * attackPoint.x + transform.up * attackPoint.y, attackRange, 0, 1 << 10);
        if (hit) boss.Bosshealth(attackDamage);
    }

    public void health(float Damage)
    {
        Health -= Damage;                                   //受到傷害回傳至變數"Health"
        TextHp.text = Health.ToString();                    //介面UI數值連接變數"Health"
        ImgHp.fillAmount = Health / HealthMax;              //條型血條顯示同步
        StartCoroutine(damageeffect());                     //協程"受傷效果"

        if (Health <= 0) Dead();                            //死亡判定
    }

    private void Dead()
    {
        EndPanel.SetActive(true);
        Health = 0;
        TextHp.text = 0.ToString();
        Ani.SetTrigger("die");
        Destroy(this, 0.5f);
        Rig.Sleep();
    }

    public IEnumerator damageeffect()
    {
        Color red = new Color(1, 0.1f, 0.1f);
        for (int i = 0; i < 4; i++)
        {
            Spr.color = red;
            yield return new WaitForSeconds(0.1f);
            Spr.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
