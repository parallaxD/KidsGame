using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTrigger : MonoBehaviour
{
    public void AchievementCheck()
    {
        if (PlayerPrefs.GetInt("Зайти в игру первый раз") == 0)
        {
            PlayerPrefs.SetInt("Зайти в игру первый раз", 1);
        }
    }
}
