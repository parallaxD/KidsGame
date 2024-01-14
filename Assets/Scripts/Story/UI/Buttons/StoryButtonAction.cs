using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryButtonAction : MonoBehaviour
{
    [SerializeField] private ButtonManager _buttonManager;
    [SerializeField] private SceneLoader _sceneLoader;
    public void OnButtonClicked()
    {
        switch (StoryManager.StoryPart)
        {
            case 1:
                _sceneLoader.LoadScene(_buttonManager.MiniGameNames[0]);
                break;
        }
    }

    void SetObjectActive(GameObject gameObject)
    {
        print('a');
        gameObject.SetActive(true);
    }
}
