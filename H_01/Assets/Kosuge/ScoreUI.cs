using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private int m_score;

    [SerializeField] private UnityEngine.UI.Image m_frame;
    [SerializeField] private UnityEngine.UI.Image m_scoreImage;

    void Start()
    {
    }

    void Update()
    {
        Color color = Color.HSVToRGB(Time.time % 1, 1, 1);

        m_frame.color = color;
        m_scoreImage.color = color;
        m_text.color = color;


        if (m_score >= 1000)
        {
            m_frame.color = color;
            m_scoreImage.color = color;
            m_text.color = color;
        }


        m_text.text = m_score.ToString("0000000000000");
    }

    public void AddScore(int num)
    {
        m_score += num;
    }
}