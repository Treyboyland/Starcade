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

    /// <summary>
    /// Activates all of the buttons
    /// </summary>
    public void ActivateButtons()
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Deactivates all of the buttons, except the one at the given index
    /// </summary>
    /// <param name="index"></param>
    public void HideAllButtonsExcept(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(i == index);
        }
    }
}
