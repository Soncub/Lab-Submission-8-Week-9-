using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : TargetBuilder
{
    public FirstTarget()
    {
        //carnivalTarget = new Target("First Target");
    }
    public override void AddSize()
    {
        carnivalTarget["size"] = "";
    }
    public override void AddSpeed()
    {
        carnivalTarget["speed"] = "";
    }
    public override void AddPoints()
    {
        carnivalTarget["points"] = "";
    }
}
