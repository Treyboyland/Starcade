using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Player", menuName = "Player", order = -99)]
public class PlayerDataSO : ScriptableObject
{
    /// <summary>
    /// Name of the player
    /// </summary>
    public string Name;

    /// <summary>
    /// Time that this player was last saved
    /// </summary>
    [SerializeField]
    long dateTimeInt = 0;

    /// <summary>
    /// Time that this player was last saved
    /// </summary>
    public DateTime LastSaveTime
    {
        get
        {
            return new DateTime(dateTimeInt);
        }
        set
        {
            dateTimeInt = value.Ticks;
        }
    }

    public ShipDataSO Ship;

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
