using UnityEngine;

public class GroundGameOver : MonoBehaviour
{
    [SerializeField] GameObject kan = null;
    [SerializeField] Rigidbody2D kanrb = null;

    [SerializeField] GameObject gameOverUI = null;


    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == kan)
        {
            gameOverUI.SetActive(true);
            Debug.Log("ゲームオーバー");
        }
    }
}
