using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public List<GameObject> targetModels;


    public int CurrentPoints;
    public Timer timer;
    private void OnEnable()
    {
        Target.AwardPoints += ChangePointTotal;
    }
    private void OnDisable()
    {
        Target.AwardPoints -= ChangePointTotal;
    }

    private void Awake()
    {
        
    }

    public void GameStart()
    {
        timer = new Timer(120000)
        {
            AutoReset = false,
            Enabled = true
        };

        timer.Elapsed += GameEnd;
        timer.Start();
    }

    public void GameEnd(object source, ElapsedEventArgs e)
    {
        //Tell the game that it is over :)
    }








    public void ChangePointTotal(int points)
    {
        CurrentPoints += points;
        Mathf.Clamp(CurrentPoints, 0, CurrentPoints);
        

    }


}
