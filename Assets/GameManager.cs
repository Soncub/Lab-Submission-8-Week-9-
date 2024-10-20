using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public List<GameObject> targetModels;


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
        Instance.GameStart();

    }

    public void GameStart()
    {


        EventManager.OnTimerStart();
        Debug.Log("Game started");

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
