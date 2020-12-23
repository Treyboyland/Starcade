using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCheckSO : ScriptableObject
{
    public abstract bool CheckAbility(PlayerDataSO player);
}
