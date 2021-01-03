using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarUi : MonoBehaviour
{
    [SerializeField]
    Image barImage = null;

    Ship playerShip;

    int maxValue;
    int initialValue;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        maxValue = playerShip.ShipData.MaxShields;
        initialValue = playerShip.CurrentShields;
        playerShip.OnShieldsChanged.AddListener(SetNewValue);

        SetNewValue(initialValue);
    }

    void SetNewValue(int currentValue)
    {
        barImage.fillAmount = 1.0f * currentValue / maxValue;
    }
}
