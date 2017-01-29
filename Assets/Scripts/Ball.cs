using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (!hasStarted)
        {
            // lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // wait for a mouse click to launch
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse clicked, launch ball");

                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    /// <summary>
    /// Event handler for collision between the ball and other game objects
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.2f, 0.2f), Random.Range(0.2f, 0.2f));

        if (hasStarted)
        {
            this.GetComponent<AudioSource>().Play();

            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
