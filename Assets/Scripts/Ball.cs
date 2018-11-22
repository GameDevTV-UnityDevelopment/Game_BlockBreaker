using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Paddle paddle;

    [SerializeField]
    private float xPush = 2f;

    [SerializeField]
    private float yPush = 15f;

    [SerializeField]
    private AudioClip[] ballSounds;

    [SerializeField]
    private float randomFactor = 0.2f;

    private Vector2 paddleToBall;
    private bool hasStarted = false;

    private AudioSource audioSource;
    private Rigidbody2D rigidBody2D;


    private void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);

        transform.position = paddlePosition + paddleToBall;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            rigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomX = Random.Range(0f, randomFactor);
        float randomY = Random.Range(0f, randomFactor);

        Vector2 velocityTweak = new Vector2(randomX, randomY);

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);

            rigidBody2D.velocity += velocityTweak;
        }
    }
}