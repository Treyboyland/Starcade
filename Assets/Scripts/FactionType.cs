using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FactionType
{
    NONE,
    PLAYER,
    RED,
    BLUE,
    YELLOW,
    GRAY,
    VIOLET
}


public struct Reputation
{
    public int PositiveReputation;
    public int NegativeReputation;
    public int EgregiousActions;
    public int ParagonActions;
    
}