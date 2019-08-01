using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGoblinFactory : GoblinFactory
{
    public RegularGoblinFactory()
    {
    }

    public override Goblin GetGoblin(GameObject go)
    {
        return go.AddComponent<RegularGoblin>();
    }
}
