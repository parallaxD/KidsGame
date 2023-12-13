using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public GameObject AchievementList;

    [SerializeField] private Sprite _neutralSprite, _highlightSprite;

    private Image _sprite;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<Image>();
    }

    public void Click()
    {
        if (AchievementList.activeSelf)
        {
            AchievementList.SetActive(false);
        }
        else AchievementList.SetActive(true);
    }
}
    