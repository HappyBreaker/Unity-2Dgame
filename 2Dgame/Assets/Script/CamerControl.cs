using UnityEngine;
using System.Collections;

public class CamerControl : MonoBehaviour
{
    [Header("追蹤物件")]
    public Transform targer;
    [Header("追蹤速度"),Range(0f,100f)]
    public float speed;
    [Header("晃動間隔"),Range(0, 1)]
    public float shakeInterval=0.5f;
    [Header("晃動值"),  Range(0, 5)]
    public float shakeValue = 0.5f;
    [Header("晃動次數"),Range(0, 10)]
    public int shakecounte = 3;


    private void Track()
    {
        Vector3 pos1 = targer.position;
        Vector3 pos2 = transform.position;
        pos1.z = -10;

        pos2 = Vector3.Lerp(pos2, pos1, 0.5f * speed);
        transform.position = pos2; 
    }
    private void LateUpdate()
    {
        Track();
    }
    /// <summary>
    /// 搖晃效果
    /// </summary>
    public IEnumerator ShakeCamera()
    {
        for (int i = 0; i <= shakecounte; i++)
        {
            //print(i);
            transform.position += Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
            transform.position -= Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
        }
    }
}
