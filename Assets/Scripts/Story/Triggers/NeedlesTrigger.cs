using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedlesTrigger : MonoBehaviour
{
    public void AchievementCheck()
    {
        if (WaveController.KillsCount >= 10)
        {
            if (PlayerPrefs.GetInt("Победить в мини-игре 1 раз") == 0)
            {
                PlayerPrefs.SetInt("Победить в мини-игре 1 раз", 1);
            }
        }
    }
}
