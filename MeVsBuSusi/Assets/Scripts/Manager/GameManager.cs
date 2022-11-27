using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private bool isOver;
    [SerializeField] private int score;

    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.Instance.PlayMusic(0);
        AudioManager.Instance.PlaySFX(0);
    }

    private void Update()
    {
        if (score >= 30)
        {
            GameWin();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        isOver = false;
    }

    public void GameOver()
    {
        if (isOver) return;

        isOver = true;
        SceneManager.LoadScene("GameOver");
    }

    public void GameWin()
    {
        if (isOver) return;

        isOver = true;
        SceneManager.LoadScene("GameWin");
    }

    public bool GetIsOver()
    {
        return isOver;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    public int GetScore()
    {
        return score;
    }
}
