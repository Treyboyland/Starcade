using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Random Check", fileName = "RandomCheck")]
public class RandomCheck : AbilityCheckSO
{
    public ComparisonTypes ComparisonType;

    public int MinValue;

    public int MaxValue;

    public int Value;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return Comparator.Compare(ComparisonType, Value, Random.Range(MinValue, MaxValue + 1));
    }
}
