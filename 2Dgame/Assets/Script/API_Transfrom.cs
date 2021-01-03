using UnityEngine;

public class API_Transfrom : MonoBehaviour
{
    public Transform Tra1;
    public Transform Tra2;

    public Camera Test1;

    #region [練習 類別.欄位]
    public SpriteRenderer Test2;
    public GameObject Test3;
    #endregion
    private void Start()
    {
        print("座標：" + Tra1.position);

        Tra2.position = new Vector3(2, 0, 0);

        //EX:靜態
        print("攝影機數量：" + Camera.allCamerasCount);

        //EX:非靜態
        Test1.backgroundColor = new Color(0.5f, 0.6f, 0.1f);


        //練習

        Test2.flipX = true;
        Test3.layer = 5;
        
        print("該圖層的顏色為："+ Test2.color);
        print("該圖層的位置：" + Test3.layer);




    }
    private void Update()
    {
        /*非靜態的使用方法
         * 欄位.(第一個字母大寫)方法(對應的引數)
         */

        Tra2.Rotate(0,0,30);
        Tra2.Translate(0.1f, 0.1f, 0,Space.World);
    }
}
