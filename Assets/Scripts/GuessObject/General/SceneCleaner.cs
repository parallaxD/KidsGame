using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCleaner : MonoBehaviour
{
    public void ClearScene()
    {
        ClearUI();
        GameObject[] allObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in allObjects)
        {
            if (obj.tag == "Destroyable")
            {
                Destroy(obj);
            }
        }
    }

    void ClearUI()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        foreach (Canvas canvas in canvases)
        {
            GameObject[] uiElements = new GameObject[canvas.transform.childCount];
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                uiElements[i] = canvas.transform.GetChild(i).gameObject;
            }

            foreach (GameObject uiElement in uiElements)
            {
                if (uiElement.tag == "Destroyable") Destroy(uiElement);
            }
        }
    }
}

