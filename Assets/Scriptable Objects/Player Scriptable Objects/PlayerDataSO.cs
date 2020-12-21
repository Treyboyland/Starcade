using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public ShipInfo Ship;

    public List<FactionAffinitySO> FactionRelations;

    public List<ItemSO> Inventory;

    public int MissionsCompleted = 0;
    public int ShipsDefeated = 0;
    public int AsteroidsDestroyed = 0;
    public int ScrapCollected = 0;
    public int TotalScrapCollected = 0;

    public bool HasItem(ItemSO item)
    {
        foreach (var inv in Inventory)
        {
            if (inv == item)
            {
                return true;
            }
        }

        return false;
    }
}
