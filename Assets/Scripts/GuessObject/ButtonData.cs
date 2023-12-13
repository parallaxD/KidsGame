using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    public bool IsRightAnswer;


    private void Awake()
    {
        IsRightAnswer = false;
        if (gameObject.GetComponent<Button>() == null)
        {
            gameObject.AddComponent<Button>();
        }

    }
}
