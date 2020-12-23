using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Shield Check", fileName = "ShieldCheck")]
public class ShieldCheckSO : AbilityCheckSO
{
    public ComparisonTypes ComparisonType;

    public int Value;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return Comparator.Compare(ComparisonType, Value, player.Ship.MaxShields);
    }
}
