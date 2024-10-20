using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreKeeper : MonoBehaviour
{

    private TMP_Text scoreText;
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        GameManager.UpdateScore += UpdateScoreText;
    }
        void OnDisable()
    {
        GameManager.UpdateScore -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.CurrentPoints.ToString(@"0000");
    }
}
