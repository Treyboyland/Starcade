using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerEventSO : ScriptableObject
{
    public abstract void DoActionOnPlayer(PlayerDataSO player);
}
