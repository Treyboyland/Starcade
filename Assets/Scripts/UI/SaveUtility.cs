using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveUtility
{
    static string PlayerSaveLocation = Application.dataPath + "/../Saves";

    public static string Error = "";

    public static bool SaveGame(PlayerDataSO player)
    {
        try
        {
            if (!Directory.Exists(PlayerSaveLocation))
            {
                Directory.CreateDirectory(PlayerSaveLocation);
            }
        }
        catch
        {
            Error = "Unable to find save path \"" + PlayerSaveLocation + "\"";
            return false;
        }

        try
        {
            var data = JsonUtility.ToJson(player);
            File.WriteAllText(PlayerSaveLocation + "/" + DateTime.Now.ToString("yyyy-mm-dd_hh-mm-ss-ffff") + ".save", data);
        }
        catch (Exception e)
        {
            Error = "Unable to write save data to file:\r\n" + e;
            return false;
        }

        Error = "Save successful";
        return true;
    }


}
