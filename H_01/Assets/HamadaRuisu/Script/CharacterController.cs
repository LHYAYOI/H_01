using UnityEngine;

public class CharacterController : MonoBehaviour
{

    enum STATE
    {
        SEPARATED,
        UNSEPARETED,
    };

    [SerializeField] STATE m_state;

    EnemyBase m_enemyBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_enemyBase = transform.parent.GetComponent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (m_state == STATE.UNSEPARETED) 
        {
            //é©ï™Ç∆ìØÇ∂ï∂éöÇ»ÇÁÉäÉäÅ[ÉX
            if (other.gameObject.layer == gameObject.layer)
            {
                m_enemyBase.ReleaseCharacter(this.gameObject);

                m_state = STATE.SEPARATED;
            }
        }
    }
}
