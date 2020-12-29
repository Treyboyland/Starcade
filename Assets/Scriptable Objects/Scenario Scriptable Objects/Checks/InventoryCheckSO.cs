using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparisons/Inventory Check", fileName = "InventoryCheck")]
public class InventoryCheckSO : AbilityCheckSO
{
    [Tooltip("The item to check")]
    [SerializeField]
    ItemSO Item = null;

    [Tooltip("Number of items to look for")]
    [SerializeField]
    uint count = 0;

    [Tooltip("Check box, if we should make sure the player does not have the item")]
    [SerializeField]
    bool playerShouldNotHaveItem = false;

    public override bool CheckAbility(PlayerDataSO player)
    {
        bool returnValue;
        if (playerShouldNotHaveItem)
        {
            returnValue = !player.Inventory.HasItem(Item);
            //Debug.LogWarning("Should not have item: " + returnValue);
            return returnValue;
        }
        else
        {
            returnValue = player.Inventory.HasItem(Item, count);
            //Debug.LogWarning("Should have item: " + returnValue);
            return returnValue;
        }
    }
}
