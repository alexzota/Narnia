using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData { get; set; }

    public EscapeRoom1Data MyEscapeRoom1Data { get; set; }

    public SaveData() {}
}

[Serializable]
public class PlayerData
{
    public string MyLevel { get; set; }
    public bool MyHasSword { get; set; }
    public float MyHealth { get; set; }
    public float MyHunger { get; set; }
    public float MySpeed { get; set; }
    public float MyX { get; set; }
    public float MyY { get; set; }
    public float MyZ { get; set; }

    public PlayerData(string level, bool hasSword, float health, float hunger, float speed, float x, float y, float z)
    {
        MyLevel = level;
        MyHasSword = hasSword;
        MyHealth = health;
        MyHunger = hunger;
        MySpeed = speed;
        MyX = x;
        MyY = y;
        MyZ = z;
    }

}

[Serializable]
public class EscapeRoom1Data
{
    public double MyPernaX { get; set; }
    public EscapeRoom1Data(double pernaX)
    {
        MyPernaX = pernaX;
    }
}