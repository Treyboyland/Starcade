using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectOnButtonPressed))]
public class ScenarioButtonController : MonoBehaviour
{
    ActionButton[] buttons;

    public ActionButton[] Buttons
    {
        get
        {
            return buttons;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        buttons = GetComponentsInChildren<ActionButton>(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
