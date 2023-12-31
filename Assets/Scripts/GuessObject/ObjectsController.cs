using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ObjectsController : MonoBehaviour
    {
        public List<Button> ButtonPrefabs;
        public List<GameObject> ObjectPrefabs;

        private Dictionary<Button, GameObject> _buttonObjectDictionary = new Dictionary<Button, GameObject>();
        private List<Vector2> _buttonsPositions = new List<Vector2>();

        [SerializeField] private Collider2D _objectSpawnArea;
        [SerializeField] private Canvas _mainCanvas;


        private List<Button> _buttonsOnScreenPrefabs = new List<Button>();
        private List<Button> _buttonsOnScreen = new List<Button>();
        
        [SerializeField] private SceneCleaner _sceneCleaner;

        [SerializeField] private AudioClip _rightAnswerCLip;


    void Start()
    {
            for (int i = 0; i < ButtonPrefabs.Count; i++)
            {
                _buttonObjectDictionary.Add(ButtonPrefabs[i], ObjectPrefabs[i]);
                ButtonPrefabs[i].GetComponent<ButtonData>().IsRightAnswer = false;
            }

            _buttonsPositions.Add(new Vector2(-650f, -680f));
            _buttonsPositions.Add(new Vector2(0f, -680f));
            _buttonsPositions.Add(new Vector2(650f, -680f));

            StartIteration();       
    }

    void SpawnObject()
    {
        var center = _objectSpawnArea.bounds.center;

        var randomIndex = Random.Range(0, _buttonsOnScreenPrefabs.Count);
        print(_buttonsOnScreenPrefabs.Count);

        GameObject objectPrefab = _buttonObjectDictionary[_buttonsOnScreenPrefabs[randomIndex]];


        _buttonsOnScreen[randomIndex].GetComponent<ButtonData>().IsRightAnswer = true;
        _buttonsOnScreen[randomIndex].GetComponent<AudioSource>().clip = _rightAnswerCLip;

        var obj = Instantiate(objectPrefab, new Vector3(0, 1f, 0f), Quaternion.identity);

        obj.transform.SetParent(_mainCanvas.transform);
        obj.transform.SetSiblingIndex(3);
        obj.transform.localScale = new Vector3(1, 1, 1);
    }

    void SpawnButtons()
    {
            RandomizeButtonsList();
            for (int i = 0; i < 3; i++)
            {
                Button button = Instantiate(ButtonPrefabs[i], _mainCanvas.transform);
                button.transform.SetSiblingIndex(i + 4);
                button.onClick.AddListener(StartIteration);
                _buttonsOnScreenPrefabs.Add(ButtonPrefabs[i]);
                _buttonsOnScreen.Add(button);
                RectTransform buttonRect = button.GetComponent<RectTransform>();
                buttonRect.anchoredPosition = _buttonsPositions[i];
            }
    }

        void RandomizeButtonsList()
        {
            int n = ButtonPrefabs.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                var value = ButtonPrefabs[k];
                ButtonPrefabs[k] = ButtonPrefabs[n];
                ButtonPrefabs[n] = value;
            }
        }

        public void StartIteration()
        {
            for (int i = 0; i < ButtonPrefabs.Count; i++)
            {
                ButtonPrefabs[i].GetComponent<ButtonData>().IsRightAnswer = false;
            }
            _sceneCleaner.ClearScene();
            _buttonsOnScreen.Clear();
            _buttonsOnScreenPrefabs.Clear();
            SpawnButtons();
            SpawnObject();
        }

}
