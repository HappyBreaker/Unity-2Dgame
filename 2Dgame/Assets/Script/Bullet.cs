using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Boss>())
        {
            collision.gameObject.GetComponent<Boss>().Bosshealth(Damage);

        }

        Destroy(gameObject);
    }
} 
