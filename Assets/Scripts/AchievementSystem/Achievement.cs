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
    //private string _name;

    //public string Name 
    //{ 
    //    get { return _name; } 
    //    set { _name = value; } 
    //}

    //private string _description;

    //public string Description
    //{
    //    get { return _description; }
    //    set { _description = value; } 
    //}


    //private bool _isUnlocked;

    //public bool IsUnlocked
    //{
    //    get { return _isUnlocked ; }
    //    set { _isUnlocked = value; }
    //}


    //private GameObject _achievementRef;

    //public GameObject AchievementRef
    //{
    //    get { return _achievementRef; }
    //    set { _achievementRef = value; }
    //}


    //public Achievement(string name, string description, GameObject achievementRef)
    //{
    //    _name = name;
    //    _description = description;
    //    _isUnlocked = false;
    //    _achievementRef = achievementRef;

    //    Load();
    //}
    
    //public bool IsAchievementUnlocked()
    //{
    //    if (!_isUnlocked)
    //    {
    //        _isUnlocked = true;
    //        Save(true);
    //        return true;
    //    }
    //    return false;
    //}

    //public void Save(bool value)
    //{
    //    _isUnlocked = value;
    //    PlayerPrefs.SetInt(_name, value ? 1 : 0);
    //    PlayerPrefs.Save();
    //}

    //public void Load()
    //{
    //    _isUnlocked = PlayerPrefs.GetInt(_name) == 1 ? true : false;
    //}
}
