using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Image backgroundImage;
    public void ChangeBackgroundImage(Sprite newBackground)
    {
        if (backgroundImage != null)
        {
            backgroundImage.sprite = newBackground;
        }
        else
        {
            Debug.LogError("Не найден компонент Image для изменения фона.");
        }
    }
}
