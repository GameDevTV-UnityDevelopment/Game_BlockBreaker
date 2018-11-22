using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,10f)]
    private float gameSpeed = 1f;

    [SerializeField]
    private int pointsPerBlockDestroyed = 10;

    [SerializeField]
    private int currentScore = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private bool isAutoPlayEnabled = false;


    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;

        scoreText.text = currentScore.ToString();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
}