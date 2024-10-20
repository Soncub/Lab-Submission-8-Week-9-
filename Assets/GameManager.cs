using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public List<GameObject> targetModels;


    public int CurrentPoints;
    public Timer timer;
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
    }








    public void ChangePointTotal(int points)
    {
        CurrentPoints += points;
        Mathf.Clamp(CurrentPoints, 0, CurrentPoints);
        

    }


}
