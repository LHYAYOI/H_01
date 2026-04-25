using System.Collections;
using UnityEngine;

public class StartSignal : MonoBehaviour
{
    [SerializeField] private GameObject readyObj = null;
    [SerializeField] private GameObject goObj = null;
    [SerializeField] private float startDelay = 3.5f;
    [SerializeField] private float goDuration = 1.0f;

    void Start()
    {
        // 時間を止める
        Time.timeScale = 0f;

        readyObj.SetActive(true);
        goObj.SetActive(false);

        // シーケンスを開始
        StartCoroutine(StartSequence());
    }

    private void OnDestroy()
    {
        // スクリプトが破棄される時に念のため時間を戻す
        Time.timeScale = 1f;
    }

    private IEnumerator StartSequence()
    {
        yield return new WaitForSecondsRealtime(startDelay);

        readyObj.SetActive(false);
        goObj.SetActive(true);

        Time.timeScale = 1f;
        Debug.Log("Go!");

        yield return new WaitForSeconds(goDuration);

        goObj.SetActive(false);
        Destroy(gameObject);
    }
}