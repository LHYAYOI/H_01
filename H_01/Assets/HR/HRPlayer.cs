using UnityEngine;
using System.Collections;

public class HRPlayer : MonoBehaviour
{
    [SerializeField] ScoreUI m_scoreUI;

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float attackPower = 10f;
    [SerializeField]
    float attackRange = 1f;
    [SerializeField]
    float attackHoriScale = 1f;

    [SerializeField]
    float slowScale = 0.5f;
    [SerializeField]
    float slowTime = 0.2f;
    [SerializeField]
    float _slowTime = 0f;

    Rigidbody2D rb;

    GameObject kan = null;
    Rigidbody2D kanrb = null;

    bool isAttacking = false;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
        }

        if (_slowTime > 0)
        {
            _slowTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 vec = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            vec.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec.x += 1;
        }
        vec = vec.normalized * speed * (_slowTime > 0 ? slowScale : 1f);
        rb.AddForce(vec);

        if (isAttacking)
        {
            isAttacking = false;

            if (kan != null)
            {
                var distance = (kan.transform.position - transform.position).magnitude;

                float x = Random.Range(-1, 1);

                Vector2 direction = new Vector2(x, 1);

                if (distance <= attackRange)
                {
                    m_scoreUI.AddScore(1000);

                    direction = direction.normalized;
                    direction.x *= attackHoriScale;
                    kanrb.AddForce(direction.normalized * attackPower, ForceMode2D.Impulse);
                }
            }
        }

    }

    public void SetSlow()
    {
        _slowTime = slowTime;
    }

    public Rigidbody2D GetKanRigidbody2D()
    {
        return kanrb;
    }
}
