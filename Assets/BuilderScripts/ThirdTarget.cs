using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTarget : TargetBuilder
{
    public ThirdTarget()
    {
       // carnivalTarget = new Target("Third Target");
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
