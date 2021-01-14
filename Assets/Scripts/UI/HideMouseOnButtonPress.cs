using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseOnButtonPress : MonoBehaviour
{
    [SerializeField]
    GameObject blocker = null;

    const int LEFT_BUTTON = 0;
    const int RIGHT_BUTTON = 1;
    const int MIDDLE_BUTTON = 2;

    bool WasMouseButtonPressed()
    {
        return Input.GetMouseButton(LEFT_BUTTON) ||
            Input.GetMouseButton(RIGHT_BUTTON) ||
            Input.GetMouseButton(MIDDLE_BUTTON);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !WasMouseButtonPressed())
        {
            Cursor.visible = false;
        }
        else if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Cursor.visible = true;
        }

        if (blocker != null)
        {
            blocker.SetActive(!Cursor.visible);
        }
    }
}
