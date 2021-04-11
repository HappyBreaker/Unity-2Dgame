using UnityEngine;

public class Note : MonoBehaviour
{
    [Header("對話框")]
    public GameObject note;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == ("Warrior"))
        {
            note.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == ("Warrior"))
        {
            note.SetActive(false);
            Destroy(gameObject);
        }
    }
}
