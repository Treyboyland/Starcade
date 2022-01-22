using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionStrength : ScriptableObject
{
    /// <summary>
    /// Faction that this data belong to
    /// </summary>
    [Tooltip("Faction that this data belong to")]
    [SerializeField]
    FactionTypeSO currentFaction;

    /// <summary>
    /// Faction that this data belong to
    /// </summary>
    /// <value></value>
    public FactionTypeSO CurrentFaction { get { return currentFaction; } }

    /// <summary>
    /// Current Health of this faction
    /// </summary>
    [Tooltip("Current Health of this faction")]
    [SerializeField]
    int health;

    /// <summary>
    /// Current Health of this faction
    /// </summary>
    /// <value></value>
    public int Health { get { return health; } set { health = value; } }

    /// <summary>
    /// How much scrap this faction currently has
    /// </summary>
    [Tooltip("How much scrap this faction currently has")]
    [SerializeField]
    int scrap;

    /// <summary>
    /// How much scrap this faction currently has
    /// </summary>
    /// <value></value>
    public int Scrap { get { return scrap; } set { scrap = value; } }


    /// <summary>
    /// How much damage this faction does
    /// </summary>
    [Tooltip("How much damage this faction does")]
    [SerializeField]
    int attackPower;

    /// <summary>
    /// How much damage this faction does
    /// </summary>
    /// <value></value>
    public int AttackPower { get { return attackPower; } set { attackPower = value; } }

    /// <summary>
    /// How much scrap this faction can accumulate while harvesting
    /// </summary>
    [Tooltip("How much scrap this faction can accumulate while harvesting")]
    [SerializeField]
    int harvestPower;

    /// <summary>
    /// How much scrap this faction can accumulate while harvesting
    /// </summary>
    /// <value></value>
    public int HarvestPower { get { return harvestPower; } set { harvestPower = value; } }
}
