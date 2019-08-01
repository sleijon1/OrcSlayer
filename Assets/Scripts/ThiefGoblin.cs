using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefGoblin : Goblin
{
    private int goblinSpeed;
    private int goldAmount;
    private string goblinType;

    public ThiefGoblin()
    {
        goblinSpeed = 5;
        goldAmount = -5;
        goblinType = "ThiefGoblin";
    }

    public override string GoblinType
    {
        get { return goblinType; }
    }
    
    public override int stealGold
    {
        set { goldAmount = value;  }
        get { return goldAmount;  }
    }

    public override int speed
    {
        set { goblinSpeed = value; }
        get { return goblinSpeed;  }
    }
}
