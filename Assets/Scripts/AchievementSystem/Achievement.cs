using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{

    public bool IsUnlocked;
    public string Name;

    public void Unlock()
    {
        IsUnlocked = true;
        PlayerPrefs.SetInt(name, 1);
    }
}
