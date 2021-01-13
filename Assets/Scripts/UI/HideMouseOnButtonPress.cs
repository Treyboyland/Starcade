using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseOnButtonPress : MonoBehaviour
{
    [SerializeField]
    GameObject blocker = null;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
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
