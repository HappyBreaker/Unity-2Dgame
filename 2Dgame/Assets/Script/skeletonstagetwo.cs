using UnityEngine;

public class skeletonstagetwo : MonoBehaviour
{
    [Header("傷害值")]
    public float Attack;

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().health(Attack);
        }
    }
}
