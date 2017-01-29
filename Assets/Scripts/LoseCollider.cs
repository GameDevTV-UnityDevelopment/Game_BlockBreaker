using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    /// <summary>
    /// Handles the collision when the ball goes out of play
    /// </summary>
    /// <param name="collider">The other Collider2D involved in this collision</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        levelManager.LoadLevel("Lose");
    }
}
