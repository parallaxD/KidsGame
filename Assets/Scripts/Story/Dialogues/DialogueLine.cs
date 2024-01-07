using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter Character;
    [TextArea(3, 10)]
    public string Line;
}
