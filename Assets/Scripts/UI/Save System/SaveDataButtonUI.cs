using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class SaveDataButtonUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameBox = null;

    [SerializeField]
    TextMeshProUGUI dateBox = null;

    [SerializeField]
    TextMeshProUGUI otherDataBox = null;


    [SerializeField]
    Button selectionButton = null;

    public int Index { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    void SetBlankData()
    {
        nameBox.text = "";
        dateBox.text = "";
        otherDataBox.text = "";
        selectionButton.interactable = false;
    }

    public void SetPlayerData(PlayerDataSO data)
    {
        if (data == null)
        {
            SetBlankData();
            return;
        }
        selectionButton.interactable = true;
        nameBox.text = data.Name;
        dateBox.text = data.LastSaveTime.ToString("yyyy-MM-dd HH-mm-ss");
        otherDataBox.text = "Insert Other Data Here";
    }
}
