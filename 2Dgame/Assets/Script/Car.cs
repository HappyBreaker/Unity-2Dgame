using UnityEngine;

public class Car : MonoBehaviour
{
    /*標題[Header]、提示[Tooltip]、範圍[Range]*/
    [Header("這是高度")]
    [Tooltip("這是高度")]
    [Range( 1, 10)]
    public int heigher = 0;
    [Header("這是寬度")]
    [Tooltip("這是寬度")]
    [Range( 2, 20)]
    public float weight = 0;
    [Header("這是品牌")]
    [Tooltip("這是品牌")]
    public string Brand;
    [Header("這是功能")]
    [Tooltip("這是功能")]
    public bool Funtion = true;

    //顏色
    public Color test1;
    public Color test2 = Color.black;
    //                              R     G     B
    public Color test3 = new Color(0.5f, 0.5f, 0.7f);
    //                                               透明度
    public Color test4 = new Color(0.4f, 0.2f, 0.4f, 0.5f);

    //維度向量
    public Vector2 V2Zero = Vector2.zero;
    public Vector2 V2One = Vector2.one;

    public GameObject OBjTest;
    public Vector3 v3Test = new Vector3(1, 1, 1);
    public Vector4 V4test = new Vector4(2, 2, 2, 2);

    //圖片 與 聲音
    public Sprite picture;
    public AudioClip Sound;

    //遊戲物件 與 元件
    public GameObject Obj1;
    public GameObject Obj2;

    public Transform tranform;
    public Camera cara;





}
