using UnityEngine;

public class CamerControl : MonoBehaviour
{
    [Header("追蹤物件")]
    public Transform targer;
    [Header("追蹤速度")]
    [Range(0f,100f)]
    public float speed;

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

}
