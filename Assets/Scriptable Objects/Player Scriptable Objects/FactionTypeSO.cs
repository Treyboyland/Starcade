using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Faction", menuName = "Factions/Faction")]
public class FactionTypeSO : ScriptableObject
{
    /// <summary>
    /// Name of this faction
    /// </summary>
    [Tooltip("Name of this faction")]
    public string Name;

    /// <summary>
    /// Description for this faction
    /// </summary>
    [Tooltip("Description for this faction")]
    [TextArea]
    public string Description;
}

