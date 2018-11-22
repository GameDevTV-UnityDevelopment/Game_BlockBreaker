using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip breakSound;

    [SerializeField]
    private GameObject blockSparklesVFX;

    [SerializeField]
    private Sprite[] hitSprites;

    private int timesHit = 0;
    private Level level;


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (gameObject.tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block '" + gameObject.name + "' has missing sprites");
        }
    }

    private void DestroyBlock()
    {
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().AddToScore();

        TriggerBreakableSFX();
        TriggerSparklesVFX();

        Destroy(gameObject);
    }

    private void TriggerBreakableSFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    }
}