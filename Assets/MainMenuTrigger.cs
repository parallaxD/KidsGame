using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTrigger : MonoBehaviour
{
    public void AchievementCheck()
    {
        if (PlayerPrefs.GetInt("����� � ���� ������ ���") == 0)
        {
            PlayerPrefs.SetInt("����� � ���� ������ ���", 1);
        }
    }
}
