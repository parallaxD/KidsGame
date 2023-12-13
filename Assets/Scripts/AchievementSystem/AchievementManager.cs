using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AchievementManager : MonoBehaviour
{
    public GameObject achListObject;
    public List<Achievement> AchievementsList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var sceneName = SceneManager.GetActiveScene().name;
        if (achListObject != null)
        {
            foreach (var item in achListObject.GetComponentsInChildren<Achievement>())
            {
                AchievementsList.Add(item);
                item.transform.gameObject.SetActive(false);
            }
        }

    }
}
