using System.Collections.Generic;
using UnityEngine;

public class CloudEnemy : EnemyBase
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rainSummonCycle = 0.15f;
    [SerializeField] private GameObject rainPrefab;
    [SerializeField] private float rainSummonRange = 2f;
    [SerializeField] private float rainSummonHeight = -0.5f;

    float rainSummonTimer = 0f;

    List<GameObject> rainList = new List<GameObject>();

    HRPlayer player;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player").GetComponent<HRPlayer>();
    }

     void OnDestroy()
    {
        foreach (var rain in rainList)
        {
            if (rain != null)
            {
                Destroy(rain);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rainSummonTimer > rainSummonCycle)
        {
            var rain = Instantiate(
                rainPrefab,
                transform.position + new Vector3(Random.Range(-rainSummonRange, rainSummonRange), rainSummonHeight, 0f),
                Quaternion.identity
            );
            rain.GetComponent<RainObj>().SetPlayer(player);
            rainList.Add(rain);

            rainSummonTimer = 0f;
        }
        else
        {
            rainSummonTimer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddForce(m_moveVector * speed);
        }
    }
}
