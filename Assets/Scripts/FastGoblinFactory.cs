using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGoblinFactory : GoblinFactory
{
    public FastGoblinFactory()
    {
    }   
    
    public override Goblin GetGoblin(GameObject go)
    {

        return go.AddComponent<FastGoblin>();
    }
}
