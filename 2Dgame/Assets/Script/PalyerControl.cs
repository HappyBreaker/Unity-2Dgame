using UnityEngine;

public class PalyerControl : MonoBehaviour
{

    public float x;

    public void Update()
    {
        GetHorizontal();
    }

    private void GetHorizontal()
    {
        x = Input.GetAxis("Horizontal");
    }

}
