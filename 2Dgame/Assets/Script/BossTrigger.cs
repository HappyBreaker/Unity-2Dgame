using UnityEngine;

public class BossTrigger : MonoBehaviour
{   
    [Header("Boss")]
    public GameObject objBoss;
    [Header("BossPanel")]
    public GameObject objPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name==("Warrior"))
        {
            objBoss.SetActive(true);
            objPanel.SetActive(true);
        }
    }
}
