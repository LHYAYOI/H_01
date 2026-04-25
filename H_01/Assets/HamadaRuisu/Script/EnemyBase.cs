using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] protected List<GameObject> m_characterList;

    protected Vector2 m_moveVector;

    ScoreUI m_scoreUI;

    public void SetMoveVector(Vector2 moveVector) 
    {
        m_moveVector = moveVector;
    }

    public void ReleaseCharacter(GameObject character)
    {
        if (m_characterList.Contains(character))
        {
            m_characterList.Remove(character);

            m_scoreUI = GameObject.Find("Text (TMP)").GetComponent<ScoreUI>();

            m_scoreUI.AddScore(2000);

            Destroy(character);
        }
    }
}
