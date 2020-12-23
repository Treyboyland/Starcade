using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Scrap Check", fileName = "ScrapCheck")]
public class ScrapCheckSO : AbilityCheckSO
{
    public ComparisonTypes ComparisonType;

    public int Value;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return Comparator.Compare(ComparisonType, Value, player.ScrapCollected);
    }
}
