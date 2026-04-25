using UnityEditor.Tilemaps;
using UnityEngine;

public class Kan : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.name == "Ground") {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            GManager.instance.SetGameOverState();
        }
    }
}
