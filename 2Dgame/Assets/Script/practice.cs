using UnityEngine;

public class practice : MonoBehaviour
{
    [Header("移動數值")]
    [Range(0f,1000f)]
    public float MoveSpead = 10.5f;
    [Header("跳越高度")]
    [Range(0f, 3000f)]
    public float JumpHeight = 100;
    [Header("是否在地上")]
    [Tooltip("是否在地上")]
    public bool InTheGround = false;
    [Header("子彈-物件")]
    [Tooltip("子彈-物件")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    [Tooltip("子彈生成點")]
    public Transform BulletPosition;
    [Header("子彈速度")]
    [Tooltip("子彈速度")]
    [Range(0,5000)]
    public int BulletSpead = 800;
    [Header("開槍音效")]
    [Tooltip("開槍音效")]
    public AudioClip Sound;
    [Header("血量")]
    [Tooltip("血量")]
    [Range(0,200)]
    public int Health = 100;

    private AudioClip Audio;
    private Rigidbody2D Rigidbody2D;
    private Animation Animation;




}
