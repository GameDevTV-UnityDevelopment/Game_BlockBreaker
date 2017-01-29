using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float minX;
    public float maxX;
    public bool autoPlay = false;

    private Ball ball;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    /// <summary>
    /// Moves the paddle with the mouse
    /// </summary>
    private void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlock, minX, maxX);

        this.transform.position = paddlePos;
    }

    /// <summary>
    /// Moves the paddle automatically
    /// </summary>
    private void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;        

        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);

        this.transform.position = paddlePos;
    }
}
