using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGoblin : Goblin
{
    private int goblinSpeed;
    private int goldAmount;
    private string goblinType;

    public FastGoblin()
    {
        goblinSpeed = 10;
        goldAmount = -1;
        goblinType = "FastGoblin";
    }

    public override string GoblinType
    {
        get { return goblinType; }
    }

    public override int stealGold
    {
        set { goldAmount = value; }
        get { return goldAmount; }
    }

    public override int speed
    {
        set { goblinSpeed = value; }
        get { return goblinSpeed; }
    }
}
