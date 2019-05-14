using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData { get; set; }

    public SaveData() {}
}

[Serializable]
public class PlayerData
{
    public string MyLevel { get; set ; }
    public bool MyHasSword { get; set; }

    public PlayerData(string level, bool hasSword)
    {
        MyLevel = level;
        MyHasSword = hasSword;
    }

}