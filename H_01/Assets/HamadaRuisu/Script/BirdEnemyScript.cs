using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsBody;

public class BirdEnemyScript : EnemyBase
{
    [SerializeField] float m_defaultSpeed = 1f;

    float m_speed;

    void Start()
    {
        m_speed = m_defaultSpeed;
    }

    void Update()
    {
        Move();
    }

    public void SetSpeed(float speed) 
    {
        m_speed = speed;
    }

    private void Move() 
    {
        transform.Translate(m_moveVector * m_speed * Time.deltaTime);
    }
    
}
