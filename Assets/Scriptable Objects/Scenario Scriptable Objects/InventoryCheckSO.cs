using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Inventory Check", fileName = "InventoryCheck")]

public class InventoryCheck : AbilityCheckSO
{
    public ItemSO Item;

    public override bool CheckAbility(PlayerDataSO player)
    {
        return player.HasItem(Item);
    }
}
