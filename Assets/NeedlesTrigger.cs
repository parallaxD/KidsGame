using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedlesTrigger : MonoBehaviour
{
    public void AchievementCheck()
    {
        if (WaveController.KillsCount >= 10)
        {
            if (PlayerPrefs.GetInt("�������� � ����-���� 1 ���") == 0)
            {
                PlayerPrefs.SetInt("�������� � ����-���� 1 ���", 1);
            }
        }
    }
}
