using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text score;
    public Button retry;
    public Canvas canvas;

    public void UpdateScore()
    {
        score.text = "Score: " + ScoreManager.score;
    }

    public void InstantiateRetryButton()
    {
        Instantiate(retry.gameObject, canvas.gameObject.transform);
    }
}
