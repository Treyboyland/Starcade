using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    /// <summary>
    /// Name for this item
    /// </summary>
    [Tooltip("The name for this item")]
    [SerializeField]
    string itemName = "";

    /// <summary>
    /// Name for this item
    /// </summary>
    public string Name
    {
        get
        {
            return itemName;
        }
    }

    /// <summary>
    /// True if this should be hidden from the player inventory
    /// </summary>
    [SerializeField]
    [Tooltip("True if this should be hidden from the player inventory")]
    bool isHidden = false;

    /// <summary>
    /// True if the player can only have one of this item
    /// </summary>
    [Tooltip("True if the player can only have one of this item")]
    [SerializeField]
    bool canPlayerOnlyHaveOne = false;

    /// <summary>
    /// True if the player can only have one of this item
    /// </summary>
    public bool CanPlayerOnlyHaveOne
    {
        get
        {
            return canPlayerOnlyHaveOne;
        }
    }

    /// <summary>
    /// Description of this item
    /// </summary>
    [TextArea]
    [Tooltip("Description of this item")]
    [SerializeField]
    string description = "";

    /// <summary>
    /// Description of this item
    /// </summary>
    public string Description
    {
        get
        {
            return description;
        }
    }
}
