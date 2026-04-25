using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Playing,
        GameOver
    }

    public static GManager instance { get; private set; }

    public int score = 0;

    [SerializeField]
    private GameState state = GameState.Title;

    [SerializeField]
    private float transitionDuration = 1f;

    private float playTime = 0f;
    private float transitionTime = 0f;

    private void Awake()
    {
        // instance がすでに存在する場合は、このオブジェクトを破棄する
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch(state) {
            case GameState.Title:
                // タイトル画面の処理
                break;
            case GameState.Playing:
                PlayingUpdate();
                break;
            case GameState.GameOver:
                GameOverUpdate();
                break;
        }
    }

    private void TitleUpdate()
    {
    }

    private void PlayingUpdate()
    {
        playTime += Time.deltaTime;
    }

    private void GameOverUpdate()
    {
        transitionTime += Time.deltaTime;

        if(transitionTime >= transitionDuration) {
            // タイトルに戻る
            SetState(GameState.Title);
            SceneManager.LoadScene("Result");
        }
    }

    public GameState GetState()
    {
        return state;
    }

    public void SetState(GameState newState)
    {
        state = newState;
    }

    public void SetPlayingState()
    {
        score = 0;
        playTime = 0f;
        transitionTime = 0f;
        SetState(GameState.Playing);
    }

    public void SetGameOverState()
    {
        transitionTime = 0f;
        SetState(GameState.GameOver);
    }
}
