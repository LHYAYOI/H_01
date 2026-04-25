using UnityEngine;

public class GroundGameOver : MonoBehaviour
{

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kan"))
        {
            Debug.Log("kan hit");
            Destroy(collision.gameObject);
        }
    }
}
