using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToUI : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetObject;
    public float zoomSpeed = 2f;
    public float zoomAmount = 5f;

    private bool isZooming = false;

    void Update()
    {
        if (isZooming)
        {
            float step = zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomAmount, step);
        }
    }

    public void ZoomIn()
    {
        isZooming = true;
    }

    public void ZoomOut()
    {
        isZooming = false;
        ResetZoom();
    }

    private void ResetZoom()
    {
        mainCamera.orthographicSize = 5f; // Установите желаемый начальный размер ортографической области видимости
    }
}
