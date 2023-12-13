using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultHandler : MonoBehaviour
{
    public int CurrentScore { get; private set; }

    public void IncreaseScore()
    {
        CurrentScore++;
    }

    public void DecreaseScore()
    {
        CurrentScore--;
    }
}
