using UnityEngine;

public class GroundGameOver : MonoBehaviour
{
    GameObject kan = null;
    Rigidbody2D kanrb = null;

    void Start()
    {
        kan = GameObject.Find("Kan");
        if (kan != null)
        {
            kanrb = kan.GetComponent<Rigidbody2D>();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == kan)
        {
            Debug.Log("ゲームオーバー");
        }
    }
}
