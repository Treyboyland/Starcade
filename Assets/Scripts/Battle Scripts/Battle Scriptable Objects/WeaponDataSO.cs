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

    /// <summary>
    /// How much time must elapse before the weapon can be fired
    /// </summary>
    [Tooltip("How much time must elapse before the weapon can be fired")]
    [SerializeField]
    float fireRate = 0;

    /// <summary>
    /// How much time must elapse before the weapon can be fired
    /// </summary>
    public float FireRate
    {
        get
        {
            return fireRate;
        }
    }
}
