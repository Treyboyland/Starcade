using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about a ship
/// </summary>
[CreateAssetMenu(fileName = "Ship", menuName = "Combat/Ship", order = 8)]
public class ShipDataSO : ScriptableObject
{
    /// <summary>
    /// Faction this ship belongs to
    /// </summary>
    [Tooltip("Faction this ship belongs to")]
    [SerializeField]
    FactionTypeSO faction = null;

    /// <summary>
    /// Faction this ship belongs to
    /// </summary>
    public FactionTypeSO Faction
    {
        get
        {
            return faction;
        }
    }

    /// <summary>
    /// Maximum Amount of health this ship can have
    /// </summary>
    [Tooltip("Maximum Amount of health this ship can have")]
    [SerializeField]
    int maxHealth = 0;

    /// <summary>
    /// Maximum Amount of health this ship can have
    /// </summary>
    /// <value></value>
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    /// <summary>
    /// Maximum Amount of shields this ship can have
    /// </summary>
    [Tooltip("Maximum Amount of shields this ship can have")]
    [SerializeField]
    int maxShields = 0;

    /// <summary>
    /// Maximum Amount of shields this ship can have
    /// </summary>
    /// <value></value>
    public int MaxShields
    {
        get
        {
            return maxShields;
        }
    }

    /// <summary>
    /// Maximum Amount of ammo this ship can have
    /// </summary>
    [Tooltip("Maximum Amount of ammo this ship can have")]
    [SerializeField]
    int maxAmmo = 0;

    /// <summary>
    /// Maximum Amount of ammo this ship can have
    /// </summary>
    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
    }

    /// <summary>
    /// True if this ship has unlimited ammo
    /// </summary>
    [Tooltip("True if this ship has unlimited ammo")]
    [SerializeField]
    bool hasUnlimitedAmmo = false;

    /// <summary>
    /// True if this ship has unlimited ammo
    /// </summary>
    public bool HasUnlimitedAmmo
    {
        get
        {
            return hasUnlimitedAmmo;
        }
    }

    /// <summary>
    /// How fast this ship initially moves
    /// </summary>
    [Tooltip("How fast this ship initially moves")]
    [SerializeField]
    float speed = 0;

    /// <summary>
    /// How fast this ship initially moves
    /// </summary>
    public float Speed { get { return speed; } }
}
