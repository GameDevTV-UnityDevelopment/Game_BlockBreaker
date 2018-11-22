using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float screenWidthInUnits = 16f;

    [SerializeField]
    private float minPositionX = 1f;

    [SerializeField]
    private float maxPositionX = 15f;

    private GameSession gameSession;
    private Ball ball;


    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), minPositionX, maxPositionX);

        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }
    }
}