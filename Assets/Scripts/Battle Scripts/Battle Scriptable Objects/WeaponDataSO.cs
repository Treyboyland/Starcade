using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Combat/Weapon", order = 9)]
public class WeaponDataSO : ScriptableObject
{
    /// <summary>
    /// List of offsets for this weapons bullets
    /// </summary>
    /// <typeparam name="OffsetAndRotation"></typeparam>
    /// <returns></returns>
    [Tooltip("List of offsets for this weapons bullets")]
    [SerializeField]
    List<OffsetAndRotation> offsets = new List<OffsetAndRotation>();

    /// <summary>
    /// List of offsets for this weapons bullets
    /// </summary>
    /// <value></value>
    public List<OffsetAndRotation> Offsets { get { return offsets; } }


    [Tooltip("")]
    [SerializeField]
    float fireRate;
}
