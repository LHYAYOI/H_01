using UnityEngine;

public class CharacterController : MonoBehaviour
{
    EnemyBase m_enemyBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //©•ª‚Æ“¯‚¶•¶š‚È‚çƒŠƒŠ[ƒX
        if (other.gameObject.layer == gameObject.layer) 
        {
            m_enemyBase.ReleaseCharacter(this.gameObject);
        }
    }
}
