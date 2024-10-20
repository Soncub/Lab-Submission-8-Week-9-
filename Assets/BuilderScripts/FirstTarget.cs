using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : TargetBuilder
{
    public FirstTarget()
    {
       
       BoxCollider boxCollider = new BoxCollider()
       {
           size = new Vector3(2, 2, 2),
       };

       //carnivalTarget = new Target();
    }
    public override void AddSize()
    {
        // carnivalTarget. = "";
    }
    public override void AddSpeed()
    {
        //carnivalTarget["speed"] = "";
    }
    public override void AddPoints()
    {
        carnivalTarget.PointValue = 10;
    }
}
