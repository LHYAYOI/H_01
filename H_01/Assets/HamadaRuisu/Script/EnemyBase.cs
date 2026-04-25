using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] protected List<GameObject> m_characterList;

    public void ReleaseCharacter(GameObject character)
    {
        if (m_characterList.Contains(character))
        {
            m_characterList.Remove(character);

            //スタティックじゃなくする
            Rigidbody2D rigidbody2D = character.GetComponent<Rigidbody2D>();

            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

            float randomX = Random.Range(-1f, 1f);

            rigidbody2D.AddForce(new Vector2(randomX, 1) * 10, ForceMode2D.Impulse);

            //親オブジェクトから切り離す
            character.transform.parent = null;
        }
    }
}
