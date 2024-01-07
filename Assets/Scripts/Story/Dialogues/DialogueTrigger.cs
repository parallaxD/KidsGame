using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;

    [SerializeField] private bool _playOnStart;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(Dialogue);
    }

    private void Start()
    {
        if (_playOnStart)
        {
            TriggerDialogue();
        }
    }
}
