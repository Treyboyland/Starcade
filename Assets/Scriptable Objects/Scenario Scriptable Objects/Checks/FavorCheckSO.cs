using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Favor Check", fileName = "FavorCheck")]
public class FavorCheckSO : AbilityCheckSO
{
    public ComparisonTypes ComparisonType;

    public int Value;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return Comparator.Compare(ComparisonType, Value, player.Ship.MaxShields);
    }
}
