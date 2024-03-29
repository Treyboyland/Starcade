﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class PlayerData : MonoBehaviour
{
    public Ship Ship;

    public int MissionsCompleted = 0;
    public int ShipsDefeated = 0;
    public int AsteroidsDestroyed = 0;
    public int ScrapCollected = 0;
    public int TotalScrapCollected = 0;
}
