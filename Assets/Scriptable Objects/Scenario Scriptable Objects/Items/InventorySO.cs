using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    [Tooltip("Items in inventory")]
    [SerializeField]
    List<InventorySlotSO> inventory = new List<InventorySlotSO>();

    /// <summary>
    /// Items in inventory
    /// </summary>
    /// <value></value>
    public List<InventorySlotSO> Inventory { get { return inventory; } }

    public void AddItem(ItemSO item, uint count = 1)
    {
        Debug.LogWarning("Adding item " + item + " Count: " + count);
        count = item.CanPlayerOnlyHaveOne ? 1 : count;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Item == item)
            {
                inventory[i].Count = item.CanPlayerOnlyHaveOne ? count : count + inventory[i].Count;
                return;
            }
        }

        var newSlot = ScriptableObject.CreateInstance<InventorySlotSO>();

        inventory.Add(InventorySlotSO.CreateSlot(item, count));
    }

    /// <summary>
    /// Returns the count of a specific item in the inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public uint GetItemCount(ItemSO item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Item == item)
            {
                return inventory[i].Count;
            }
        }

        return 0;
    }

    /// <summary>
    /// Removes a number of items in inventory. Returns true if 'count' items were successfully removed.
    /// False if item does not exist in inventory, or if inventory does not contain at least 'count' items.
    /// If false, inventory will remain unchanged.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool RemoveItem(ItemSO item, uint count = 1)
    {
        for (int i = inventory.Count - 1; i >= 0; i++)
        {
            if (inventory[i].Item == item)
            {
                if (inventory[i].Count < count)
                {
                    return false;
                }
                inventory[i].Count -= count;
                if (inventory[i].Count == 0)
                {
                    inventory.RemoveAt(i);
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Returns true if the item exists in the inventory, and
    /// at least 'count' items exist in the inventory. False otherwise
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool HasItem(ItemSO item, uint count = 1)
    {
        foreach (var slot in inventory)
        {
            if (slot.Item == item)
            {
                return slot.Count >= count;
            }
        }
        return false;
    }
}

[CreateAssetMenu(fileName = "InventorySlot", menuName = "Inventory/Inventory Slot", order = 1)]
public class InventorySlotSO : ScriptableObject
{
    /// <summary>
    /// Item taking this slot
    /// </summary>
    [SerializeField]
    [Tooltip("Item taking this slot")]
    ItemSO item;

    /// <summary>
    /// Item taking this slot
    /// </summary>
    /// <value></value>
    public ItemSO Item { get { return item; } }

    /// <summary>
    /// Number of items in this slot
    /// </summary>
    [SerializeField]
    [Tooltip("Number of items in this slot")]
    uint count;

    /// <summary>
    /// Number of items in this slot
    /// </summary>
    /// <value></value>
    public uint Count { get { return count; } set { count = value; } }

    /// <summary>
    /// Creates a new inventory slot with the given item and count
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static InventorySlotSO CreateSlot(ItemSO item, uint count)
    {
        var newSlot = ScriptableObject.CreateInstance<InventorySlotSO>();
        newSlot.item = item;
        newSlot.count = count;

        return newSlot;
    }
}