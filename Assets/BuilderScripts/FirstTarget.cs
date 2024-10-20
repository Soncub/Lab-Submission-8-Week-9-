using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : TargetBuilder
{
    public FirstTarget()
    {
       BoxCollider boxCollider = new BoxCollider(){};
       carnivalTarget = new Target(GameManager.Instance.targetModels[0],boxCollider);
    }
    public override void AddSize()
    {
        // carnivalTarget. = "";
    }
    public override void AddSpeed()
    {
        carnivalTarget.Speed = 1;
    }
    public override void AddPoints()
    {
        carnivalTarget.PointValue = 3;
    }
}
