using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionTypeSO : ScriptableObject
{
    public string Name;

    public string Description;
}


public class FactionAffinitySO : ScriptableObject
{
    FactionTypeSO Faction;

    public int PositiveReputation;
    public int NegativeReputation;
    public int EgregiousActions;
    public int ParagonActions;
}
