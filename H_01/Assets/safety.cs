using UnityEngine;

public class safety : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11 || transform.position.x > 11) 
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            transform.position = new Vector2(0, 0);
        }
    }
}
