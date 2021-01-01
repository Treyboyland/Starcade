using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Combat/Ship", order = 8)]
public class ShipDataSO : ScriptableObject
{
    public int MaxHealth;

    public int MaxShields;

    public int MaxAmmo;

    public bool HasUnlimitedAmmo;
}
