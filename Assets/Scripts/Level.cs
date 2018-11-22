using UnityEngine;

public class Level : MonoBehaviour
{
    private int breakableBlocks;

    private SceneLoader sceneLoader;


    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
}