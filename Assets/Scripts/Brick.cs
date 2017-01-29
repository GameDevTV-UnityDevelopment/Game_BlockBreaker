using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;

    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        isBreakable = (this.tag == "Breakable");

        // keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();     // TODO: This is very inefficient
    }

    /// <summary>
    /// Event handler for collision between the ball and bricks
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.8f);

        if (isBreakable)
        {
            HandleHits();
        }
    }

    /// <summary>
    /// Updates the damaged brick sprite or destroys the brick depending
    /// </summary>
    private void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;

        timesHit++;

        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    /// <summary>
    /// Creates a smoke puff at the position of the destroyed brick
    /// </summary>
    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    /// <summary>
    /// Updates the brick's sprite based on the number of hits it has received
    /// </summary>
    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;

        // check that sprite exists for the given index
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    /// <summary>
    /// Simulates a win condition
    /// </summary>
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
