using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactionAffinity", menuName = "Factions/Affinity")]
public class FactionAffinitySO : ScriptableObject
{
    public FactionTypeSO Faction;

    public int PositiveReputation;
    public int NegativeReputation;
    public int EgregiousActions;
    public int ParagonActions;

    public int CalculateAffinity()
    {
        //TODO: Not sure if each faction should have their own affinity calculation...
        return PositiveReputation - NegativeReputation + 10 * (ParagonActions - EgregiousActions);
    }
}