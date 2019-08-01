using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefGoblinFactory : GoblinFactory
{
    public ThiefGoblinFactory()
    {
    }

    public override Goblin GetGoblin(GameObject go)
    {
        return go.AddComponent<ThiefGoblin>();
    }
}
