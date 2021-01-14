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
    public InventorySO Inventory { get { return inventory; } protected set { inventory = value; } }

    public int MissionsCompleted = 0;
    public int ShipsDefeated = 0;
    public int AsteroidsDestroyed = 0;
    public int ScrapCollected = 0;
    public int TotalScrapCollected = 0;

    /// <summary>
    /// How many game iterations have passed since start
    /// </summary>
    public uint TotalCycles = 0;


    /// <summary>
    /// Copies data from other into this object
    /// </summary>
    /// <param name="other"></param>
    public void CopyData(PlayerDataSO other)
    {
        //I think I can use reflection here without issue...
        foreach (var field in this.GetType().GetFields())
        {
            field.SetValue(this, field.GetValue(other));
        }

        // foreach (var property in other.GetType().GetProperties())
        // {
        //     property.SetValue(this, property.GetValue(other));
        // }

    }

    public void IncrementCycle()
    {
        TotalCycles++;
    }
}
