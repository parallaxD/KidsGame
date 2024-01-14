using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttons;
    [SerializeField] private DialogueManager _dialogueManager;

    public List<string> MiniGameNames;

    private void Start()
    {
        SetButtonsActive(false);
    }

    void Update()
    {
        if (_dialogueManager.IsDialogueComplete())
        {
            SetButtonsActive(true);
        }
        else
        {
            SetButtonsActive(false);
        }
    }

    void SetButtonsActive(bool isActive)
    {
        foreach (var button in _buttons)
        {
            button.SetActive(isActive);
        }
    }
}
