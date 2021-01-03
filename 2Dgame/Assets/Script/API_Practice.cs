using UnityEngine;

public class API_Practice : MonoBehaviour
{
    public void Start()
    {
        #region
        /* print("隨機值：" + Random.value);
         print("圓周率：" + Mathf.PI);

         Cursor.visible = false;

         Time.timeScale = 2;

         print("隨機100~500的值：" + Random.Range(100f, 500f));

         int test = Mathf.Abs(-545);
         print("絕對值為：" + test);*/
        #endregion

        int CameraCount = Camera.allCameras.Length;
        print("現在有" + CameraCount + "台攝影機");
        //print("現在有" + Camera.allCamerasCount + "台攝影機");

        float gravty = Physics2D.gravity.magnitude;
        print("環境重力" + gravty + "G");
        //print("環境重力" + Physics2D.gravity + "G");

        Physics2D.gravity = new Vector2(0, -20);

        //Application.OpenURL("https://www.youtube.com/?gl=TW&tab=r1");

        print("9.9999去小數點為：" + Mathf.Floor(9.9999f));

        print("兩點距離：" + Vector3.Distance(new Vector3(1, 1, 1), new Vector3(4, 4, 4)));


    }

    private void Update()
    {
        //print("是否輸入任意鍵" + Input.anyKey);

        //print("時間：" + Time.timeSinceLevelLoad);

        print("是否輸入空白健" + Input.GetKey("space"));


    }
}
