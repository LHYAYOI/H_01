using System.Collections.Generic;
using UnityEngine;

public class WindEnemy : EnemyBase
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float windPower = 2f;
    [SerializeField] private float hitrange = 2f;
    [SerializeField] private Vector2 windVec = new Vector2(1f, 0f);

    HRPlayer player;

    Rigidbody2D rb;

    GameObject kan = null;
    Rigidbody2D kanrb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        kan = GameObject.Find("Kan");
        if (kan != null)
        {
            kanrb = kan.GetComponent<Rigidbody2D>();
        }
    }

    void OnDestroy()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11 || transform.position.x > 11)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (kanrb != null)
        {
            Vector2 playerPos = kanrb.transform.position;
            Vector2 enemyPos = transform.position;
            if (Vector2.Distance(playerPos, enemyPos) < hitrange)
            {
                kanrb.AddForce(windVec.normalized * windPower, ForceMode2D.Impulse);
            }
        }

        if (rb != null)
        {
            rb.AddForce(m_moveVector * speed);
        }
    }
}
