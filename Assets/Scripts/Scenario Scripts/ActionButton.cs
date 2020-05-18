using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI), typeof(Button))]
public class ActionButton : MonoBehaviour
{
    TextMeshProUGUI textBox = null;
    Button button = null;

    string description = "";

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
            if (textBox != null)
            {
                textBox.text = description;
            }
        }
    }

    //Id for this action button
    public int Id { get; set; }

    public bool Interactable 
    {
        get
        {
            return button.interactable;
        }
        set
        {
            button.interactable = value;
        }
    }

    public IntEvent OnActionChosen = new IntEvent();

    private void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnActionChosen.Invoke(Id));
    }

}
