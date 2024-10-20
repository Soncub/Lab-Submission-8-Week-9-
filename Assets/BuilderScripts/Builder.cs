using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    void Start()
    {
        TargetBuilder builder;
        Shop shop = new Shop();

        builder = new FirstTarget();
        shop.Construct(builder);
        //builder.CarnivalTarget.Show();

        builder = new SecondTarget();
        shop.Construct(builder);
        //builder.CarnivalTarget.Show();

        builder = new ThirdTarget();
        shop.Construct(builder);
        //builder.CarnivalTarget.Show();
    }
}
public class Shop
{
    public void Construct(TargetBuilder targetBuilder)
    {
        targetBuilder.AddSize();
        targetBuilder.AddSpeed();
        targetBuilder.AddPoints();
    }
}