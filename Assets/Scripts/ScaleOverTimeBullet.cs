using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleOverTimeBullet : ScaleOverTime
{
    [SerializeField]
    BulletDataSO bulletDataSO;

    protected override float SecondsToScale { get { return bulletDataSO.SecondsToLive; } }
}
