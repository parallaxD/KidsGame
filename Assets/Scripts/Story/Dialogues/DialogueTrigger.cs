using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;

    [SerializeField] private bool _playOnStart;

    [SerializeField] private bool _startMiniGame;
    [SerializeField] private string _sceneName;
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(Dialogue, _startMiniGame, _sceneName);
    }

    private void Start()
    {
        if (_playOnStart)
        {
            TriggerDialogue();
        }
    }

}
