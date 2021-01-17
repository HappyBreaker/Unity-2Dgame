using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Boss>())
        {
            collision.gameObject.GetComponent<Boss>().health(Damage);
        }
    }
} 
