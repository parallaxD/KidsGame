using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HoldToDisplayText : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI displayText;
    public string textToDisplay = "Ваш текст здесь";

    private bool isTouching = false;

    [SerializeField] private bool _isStoryObject;

    private void Start()
    {
        displayText.text = "";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        displayText.text = textToDisplay;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isStoryObject)
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        isTouching = false;
        displayText.text = "";
    }
}

