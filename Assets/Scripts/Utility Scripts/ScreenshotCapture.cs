using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ScreenshotCapture : MonoBehaviour
{
    [SerializeField]
    string prefix = "Screenshot";

    [SerializeField]
    bool usePersistentDirectory = false;

    public class ScreenshotEvent : UnityEvent<string> { }

    public ScreenshotEvent OnScreenshotTaken = new ScreenshotEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            string fileName = (usePersistentDirectory ? (Application.persistentDataPath + '/') : "") + prefix + '-' + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + ".png";
            ScreenCapture.CaptureScreenshot(fileName, 1);
            OnScreenshotTaken.Invoke(fileName);
            //Debug.LogWarning("Screenshot Saved at location: " + fileName);
        }
    }
}
