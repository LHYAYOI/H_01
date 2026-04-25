using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private int m_score;
    [SerializeField] private string a;
    void Start()
    {
    }

    void Update()
    {
        m_text.text = m_score.ToString("0000000000000");
    }

    public void AddScore(int num)
    {
        m_score += num;
    }
}