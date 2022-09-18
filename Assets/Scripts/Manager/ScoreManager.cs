using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: 0";
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
    }
}
