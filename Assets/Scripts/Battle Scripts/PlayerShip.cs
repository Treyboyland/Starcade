using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : ShipInfo
{
    private void Start()
    {
        if(PlayerDataSingleton.Instance != null)
        {
            this.SetData(PlayerDataSingleton.Instance.Data.Ship);
        }
    }
}
