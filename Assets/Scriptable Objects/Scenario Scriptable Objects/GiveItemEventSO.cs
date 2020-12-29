using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveItem", menuName = "Player Event/Give Item")]
public class GiveItemEventSO : PlayerEventSO
{
    [SerializeField]
    ItemSO item = null;

    [SerializeField]
    uint count = 1;

    public override void DoActionOnPlayer(PlayerDataSO player)
    {
        player.Inventory.AddItem(item, count);
    }
}
