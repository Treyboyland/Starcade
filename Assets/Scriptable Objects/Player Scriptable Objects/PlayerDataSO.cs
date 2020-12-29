using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player", order = -2)]
public class PlayerDataSO : ScriptableObject
{
    public ShipInfo Ship;

    public List<FactionAffinitySO> FactionRelations;

    [Tooltip("Inventory belonging to this player")]
    [SerializeField]
    InventorySO inventory = null;

    /// <summary>
    /// Player inventory
    /// </summary>
    /// <value></value>
    public InventorySO Inventory { get { return inventory; } }

    public int MissionsCompleted = 0;
    public int ShipsDefeated = 0;
    public int AsteroidsDestroyed = 0;
    public int ScrapCollected = 0;
    public int TotalScrapCollected = 0;
}
