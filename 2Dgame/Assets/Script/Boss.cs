using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 
using System.Collections;


[RequireComponent(typeof(AudioSource),typeof(Rigidbody2D),typeof(CapsuleCollider2D))]

public class Boss : MonoBehaviour
{
    [Header("移動速度"),Range(0, 100)]
    public float MoveSpeed = 10;
    [Header("攻擊範圍"),Range(0, 100)]
    public float RangeAtk;
    [Header("攻擊CD"), Range(0, 10)]
    public float CDAtk = 3.5f;
    [Header("傷害"),  Range(0, 200)]
    public int Attack = 20;
    [Header("傷害延遲時間"), Range(0, 200)]
    public float AtkDelay = 0.7f;

    [Header("血量"),  Range(0, 2000)]
    public float Health;
    [Header("血量文字")]
    public Text TextHp;
    [Header("血量圖片")]
    public Image ImgHp;

    [Header("死亡事件")]
    public UnityEvent OnDead;

    [Header("音效")]
    public AudioClip Sound;

    [Header("攻擊範圍位移")]
    public Vector3 ofSetAtk;
    [Header("攻擊判定範圍")]
    public Vector3 SizeAtk;

    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    private float HealthMax;
    private Player player;
    private float Timer; //計時器
    private CamerControl Cam;
    private bool IsSecond;
    private ParticleSystem ParSystem;

    private void Start()
    {
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        ParSystem = GameObject.Find("skeletonstagetwo").GetComponent<ParticleSystem>();
       
        HealthMax = Health;

        player = FindObjectOfType<Player>(); //透過元件去尋找物件 注意!!不可同元件出現在兩個不同的物件

        TextHp.text = Health.ToString();
        ImgHp.fillAmount = Health / HealthMax;

        Cam = FindObjectOfType<CamerControl>();
        Rig.AddForce(transform.right);
    }

    void Update()
    {
        if (Ani.GetBool("BossDead")) return;
        move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * ofSetAtk.x + transform.up * ofSetAtk.y, SizeAtk);

        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, RangeAtk);
    }

    private void move()
    {
        Rig.WakeUp();
        AnimatorStateInfo info = Ani.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Boss-Attack") || info.IsName("Boss-Hit")) return;
        
        /*
        if(transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
        float y = transform.position.x > player.transform.position.x ? 180 : 0; //三元運算子 布林值？結果A：結果B
        transform.eulerAngles = new Vector3(0, y, 0);

        float dis = Vector2.Distance(transform.position, player.transform.position); //距離=二維.距離(A座標,B座標)
        if (dis > RangeAtk)
        {
            //Rig.AddForce(transform.right);
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * MoveSpeed);
        }
        else
        {
            attack();
        }

        Ani.SetBool("Walk", Rig.velocity.magnitude > 0);
        
        
        
        //print(Rig.velocity.magnitude); 檢查用
    }
    /// <summary>
    /// 攻擊冷卻與攻擊行為
    /// </summary>
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
            StartCoroutine(DelaySendDamage()); //啟動協同程序(程序名稱());
        }
    }
    
    /// <summary>
    /// 延遲傳送傷害,IEnumerator 允許傳回時間
    /// </summary>
    private IEnumerator DelaySendDamage()
    {
        //等待延遲時間
        yield return new WaitForSeconds(AtkDelay);    
        //物理碰撞 =2D物理,盒形物理範圍(中心點,範圍,角度,圖層)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * ofSetAtk.x + transform.up * ofSetAtk.y, SizeAtk, 0, 1 << 9);
        if (hit) player.health(Attack);
        
        StartCoroutine(Cam.ShakeCamera()); // 搖晃觸發

        if (IsSecond)
        {
            ParSystem.Play();
        }

    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="Damage">接收傷害</param>
    public void health(float Damage)
    {
        Health -= Damage;
        Ani.SetTrigger("GetHit");
        TextHp.text = Health.ToString();
        ImgHp.fillAmount = Health / HealthMax;

        if (Health <= HealthMax * 0.7)
        {
            IsSecond = true;
            RangeAtk = 30;
        }

        if (Health <= 0) Dead();
    }
    /// <summary>
    /// 死亡判定與動畫
    /// </summary>
    private void Dead()
    {
        OnDead.Invoke();

        Health = 0;
        TextHp.text = 0.ToString();
        Ani.SetBool("BossDead", true);

        GetComponent<CapsuleCollider2D>().enabled = false;  //取得元件<CapsuleCollider2D>().啟動 = 關閉
        Rig.Sleep();
        Rig.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
