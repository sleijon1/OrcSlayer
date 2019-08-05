using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goblin : MonoBehaviour
{
    public abstract string GoblinType { get; }
    public abstract int speed { get; set; }
    public abstract int stealGold { get; set; }
}
