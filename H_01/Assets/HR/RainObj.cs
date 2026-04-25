using System.Collections.Generic;
using UnityEngine;

public class RainObj : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float hitrange = 2f;

    HRPlayer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnDestroy()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPos = player.transform.position;
            Vector2 rainPos = transform.position;
            if (Vector2.Distance(playerPos, rainPos) < hitrange)
            {
                player.SetSlow();
            }
        }

        lifetime -= Time.fixedDeltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayer(HRPlayer player)
    {
        this.player = player;
    }
}
