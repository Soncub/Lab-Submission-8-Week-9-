using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public static Action UpdateScore;

    


    public int CurrentPoints;
    private void OnEnable()
    {
        Target.AwardPoints += ChangePointTotal;
       EventManager.TimerStop += GameEnd;
    }
    private void OnDisable()
    {
        Target.AwardPoints -= ChangePointTotal;
        EventManager.TimerStop -= GameEnd;
    }

    private void Awake()
    {
        Instance = this;
        GameStart();

    }

    public void GameStart()
    {
        Debug.Log("Game started");
        EventManager.OnTimerStart();

    }

    public void GameEnd()
    {
        //Tell the game that it is over :)
        Debug.Log("Game is over.");

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void ChangePointTotal(int points)
    {
        CurrentPoints += points;
        Mathf.Clamp(CurrentPoints, 0, CurrentPoints);
        UpdateScore?.Invoke();
        

    }


}
