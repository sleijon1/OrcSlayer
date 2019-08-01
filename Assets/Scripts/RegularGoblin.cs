using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGoblin : Goblin
{
    private int goblinSpeed;
    private int goldAmount;
    private string goblinType;

    public RegularGoblin()
    {
        goblinSpeed = 1;
        goldAmount = -1;
        goblinType = "RegularGoblin";
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
