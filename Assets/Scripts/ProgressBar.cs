using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int MaximumValue;
    public int CurrentValue;
    [SerializeField] private Image _mask;

    private void Start()
    {
        CurrentValue = 0;
    }
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        var fillAmount = (float)CurrentValue / (float)MaximumValue;
        _mask.fillAmount = fillAmount;
    }

    public void IncreaseCurentValue()
    {
        CurrentValue++;
    }

    public void DecreaseCurentValue()
    {
        CurrentValue--;
    }

    public void ResetValue()
    {
        CurrentValue = 0;
        ResultHandler.CurrentScore = CurrentValue;
    }
}
