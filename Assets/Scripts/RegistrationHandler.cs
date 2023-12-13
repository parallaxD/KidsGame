using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistrationHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }


    public void SetPlayerName()
    {
        string playerName = _inputField.text;
        if (playerName != string.Empty)
        {
            PlayerPrefs.SetString("PlayerName", playerName);
        }
        PlayerPrefs.Save();
    }
}
