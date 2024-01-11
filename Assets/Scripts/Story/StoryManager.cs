using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static int StoryPart = 1;

    [SerializeField] private List<GameObject> _aviaryCanvases;

    [SerializeField] private List<GameObject> _dialogueBoxes;

    [SerializeField] private List<GameObject> _characters;

    [SerializeField] private Dictionary<GameObject, GameObject> canvasDialogueDictionary = new Dictionary<GameObject, GameObject>();

    private void Awake()
    {
        switch (StoryPart)
        {

            case 2:
                _aviaryCanvases[0].SetActive(true);
                for (int i = 1; i < _aviaryCanvases.Count; i++)
                {
                    _aviaryCanvases[i].SetActive(false);
                }
                break;
            case 3:
                _aviaryCanvases[2].SetActive(true);
                for (int i = 0; i < _aviaryCanvases.Count - 1; i++)
                {
                    _aviaryCanvases[i].SetActive(false);
                }
                break;
        }
    }
}
