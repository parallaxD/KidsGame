using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] TextMeshProUGUI _characterName;
    [SerializeField] TextMeshProUGUI _dialogueArea;

    [SerializeField] private List<GameObject> _dialogueComponents;

    private Queue<DialogueLine> _lines;

    [SerializeField] private bool _isActive;
    [SerializeField] private float _typingSpeed = 0.2f;

    [SerializeField] private BackgroundChanger _backgroundChanger;

    [SerializeField] private bool _shouldChangeBackground;

    private int _currentIndex;
    [SerializeField] private int _indexToChange;

    [SerializeField] private Sprite _imageToChange;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _isActive = true;
        _lines.Clear();
        foreach (var dialogueLine in dialogue.DialogueLines)
        {
            _lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (_lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (_shouldChangeBackground && _currentIndex == _indexToChange)
        {
            _backgroundChanger.ChangeBackgroundImage(_imageToChange);
        }



        DialogueLine currentLine = _lines.Dequeue();

        if (currentLine.DisableSpriteRenderer)
        {
            DisableSpriteRenderer(currentLine.Character.CharacterObject);
        }

        if (currentLine.DestroyCharacter)
        {
            DestroyCharacter(currentLine.Character.CharacterObject);
        }

        if (currentLine.Character.Name == "Игрок")
        {
            var playerName = PlayerPrefs.GetString("PlayerName");
            _characterName.text = playerName;
        }
        else _characterName.text = currentLine.Character.Name;

        if (currentLine.Character.CharacterObject != null)
        {
            currentLine.Character.CharacterObject.GetComponent<SpriteRenderer>().sprite = currentLine.Character.CurrentEmotion;
        }

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));

        _currentIndex++;
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        _dialogueArea.text = String.Empty;
        foreach (var letter in dialogueLine.Line.ToCharArray())
        {
            _dialogueArea.text += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
    }

    private void EndDialogue()
    {
        _isActive = false;
        foreach (var component in _dialogueComponents)
        {
            Destroy(component);
        }
    }

    private void DisableSpriteRenderer(GameObject character)
    {
        character.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void DestroyCharacter(GameObject character)
    {
        Destroy(character);
    }
}
