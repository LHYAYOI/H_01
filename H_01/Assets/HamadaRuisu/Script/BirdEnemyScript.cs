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
        MoveRight();

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            ReleaseCharacter(m_characterList[0]);
        }

        if (Input.GetKey(KeyCode.O)) 
        {
            transform.Rotate(0, 0, 1);
        }
    }

    public void SetSpeed(float speed) 
    {
        m_speed = speed;
    }

    private void MoveRight() 
    {
        transform.Translate(m_moveVector * m_speed * Time.deltaTime);
    }
    
}
