using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject _dialogueBox;

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

    [SerializeField] private SceneLoader _sceneLoader;

    private bool _startMiniGame;
    private string _sceneName;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _lines = new Queue<DialogueLine>();
    }

    private void Start()
    {
        switch (StoryManager.StoryPart)
        {
            case 1:
                _shouldChangeBackground = true;
                break;
            case 2:
                _shouldChangeBackground = false;
                break;
        }
    }

    public void StartDialogue(Dialogue dialogue, bool startMiniGame, string sceneName)
    {
        _startMiniGame = startMiniGame;
        _sceneName = sceneName;
        if (!_dialogueBox.activeSelf)
        {
            _dialogueBox.SetActive(true);
        }
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
            DisableCharacterSpriteRenderer(currentLine.Character.CharacterObject);
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
        if (_startMiniGame)
        {
            _sceneLoader.LoadScene(_sceneName);
        }
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void DisableCharacterSpriteRenderer(GameObject character)
    {
        character.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void DestroyCharacter(GameObject character)
    {
        Destroy(character);
    }

    public bool IsDialogComplete()
    {
        if (_isActive)
        {
            return false;
        }
        return true;
    }
}
