using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Health Check", fileName = "HealthCheck")]
public class HealthCheckSO : AbilityCheckSO
{
    public ComparisonTypes ComparisonType;

    public int Value;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return Comparator.Compare(ComparisonType, Value, player.Ship.MaxHealth);
    }
}
