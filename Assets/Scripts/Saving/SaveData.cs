using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>SaveData</c> includes all the different objects that need to be saved.
/// </summary>
[Serializable]
public class SaveData
{
    /// <summary>
    /// The player data object to be saved
    /// </summary>
    public PlayerData MyPlayerData { get; set; }

    /// <summary>
    /// The object holding all EscapeRoom1 data to be saved
    /// </summary>
    public EscapeRoom1Data MyEscapeRoom1Data { get; set; }

    /// <summary>
    /// Empty constructor.
    /// </summary>
    public SaveData() {}
}

/// <summary>
/// Class <c>PlayerData</c> inlcudes all player data that needs to be saved.
/// </summary>
[Serializable]
public class PlayerData
{
    /// <summary>
    /// The current level
    /// </summary>
    public string MyLevel { get; set; }
    /// <summary>
    /// Indicates whether the sword has been picked up or not
    /// </summary>
    public bool MyHasSword { get; set; }
    /// <summary>
    /// The player's health
    /// </summary>
    public float MyHealth { get; set; }
    /// <summary>
    /// The player's hunger
    /// </summary>
    public float MyHunger { get; set; }
    /// <summary>
    /// The player's movement speed
    /// </summary>
    public float MySpeed { get; set; }
    /// <summary>
    /// The player's x coordinate
    /// </summary>
    public float MyX { get; set; }
    /// <summary>
    /// The player's y coordinate
    /// </summary>
    public float MyY { get; set; }
    /// <summary>
    /// The player's z coordinate
    /// </summary>
    public float MyZ { get; set; }
    /// <summary>
    /// The dialog line reached by the player
    /// </summary>
    public int MyDialogueLine { set; get; }

    /// <summary>
    /// Parametrized constructor.
    /// </summary>
    /// <param name="level">The current level</param>
    /// <param name="hasSword">Indicates whether the sword has been picked up or not</param>
    /// <param name="health">The player's health</param>
    /// <param name="hunger">The player's hunger</param>
    /// <param name="speed">The player's movement speed</param>
    /// <param name="x">The player's x coordinate</param>
    /// <param name="y">The player's y coordinate</param>
    /// <param name="z">The player's z coordinate</param>
    /// <param name="DialogueLine">The dialog line reached by the player</param>
    public PlayerData(string level, bool hasSword, float health, float hunger, float speed, float x, float y, float z, int DialogueLine)
    {
        MyLevel = level;
        MyHasSword = hasSword;
        MyHealth = health;
        MyHunger = hunger;
        MySpeed = speed;
        MyX = x;
        MyY = y;
        MyZ = z;
        MyDialogueLine = DialogueLine;
    }

}

/// <summary>
/// Class <c>EscapeRoom1Data</c> inlcudes all EscapeRoom data that needs to be saved.
/// </summary>
[Serializable]
public class EscapeRoom1Data
{
    /// <summary>
    /// The pillow's x coordinate
    /// </summary>
    public double MyPernaX { get; set; }
    /// <summary>
    /// Parametrized constructor.
    /// </summary>
    /// <param name="pernaX">The pillow's x coordinate</param>
    public EscapeRoom1Data(double pernaX)
    {
        MyPernaX = pernaX;
    }
}