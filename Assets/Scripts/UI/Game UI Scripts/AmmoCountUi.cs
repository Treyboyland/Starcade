using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AmmoCountUi : MonoBehaviour
{
    TextMeshProUGUI textbox;

    // Start is called before the first frame update
    void Start()
    {
        var ship = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        textbox = GetComponent<TextMeshProUGUI>();
        ship.OnAmmoChanged.AddListener(SetAmmo);
        SetAmmo(ship.CurrentAmmo);
    }

    void SetAmmo(int ammo)
    {
        textbox.text = "Ammo\r\n" + ammo;
    }
}
