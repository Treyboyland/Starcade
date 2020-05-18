using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOnButtonPressed : MonoBehaviour
{
    [SerializeField]
    List<Selectable> objects = new List<Selectable>();

    [SerializeField]
    Selectable objectToSelect = null;

    [SerializeField]
    bool shouldRunCheck = false;

    public bool ShouldRunCheck
    {
        get
        {
            return shouldRunCheck;
        }
        set
        {
            shouldRunCheck = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRunCheck && Input.anyKeyDown && !AreAnyObjectsSelected())
        {
            objectToSelect.Select();
        }
    }

    bool AreAnyObjectsSelected()
    {
        foreach (var obj in objects)
        {
            //TODO: Assumes all selected objects are using animator components
            if (obj.animator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
            {
                return true;
            }
        }
        return false;
    }
}
