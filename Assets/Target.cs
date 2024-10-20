using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : IGetHit
{

    public static Action<int> AwardPoints;


    public int PointValue;
    public GameObject TargetModel;
    public float Speed;

    public BoxCollider Hitbox;
    public Target(GameObject targetModel, BoxCollider boxCollider)
    {
        TargetModel = targetModel;
        Hitbox = boxCollider;
    }




    private void Awake()
    {
        //Instantiate(TargetModel);
        //var box = AddComponent<BoxCollider>();
        //box = Hitbox;
    }


    public void GetHit()
    {
        AwardPoints?.Invoke(PointValue);
    }

    

}
