using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused;

    public void PauseGame()
    {
        IsGamePaused = true;
    }

    public void UnpauseGame()
    {
        IsGamePaused = false;
    }

    public void IncreaseStoryPart()
    {
        StoryManager.StoryPart++;
    }

    public void ResetStoryPart()
    {
        StoryManager.StoryPart = 0;
    }
}
