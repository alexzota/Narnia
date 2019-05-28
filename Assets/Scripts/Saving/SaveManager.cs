using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Class <c>SaveManager</c> helps in managing the save and load process.
/// </summary>
public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// Implements the save feature.
    /// </summary>
    public void Save(string path)
    {
        Player player = Player.GetInstance();
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(path, FileMode.Create);
            SaveData data = new SaveData();
            SavePlayer(data);
            bf.Serialize(fs, data);
            fs.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log("Saving issue!" + e);
        }
    }

    /// <summary>
    /// Initializes the PlayerData component.
    /// </summary>
    /// <param name="data">The entire save object</param>
    private void SavePlayer(SaveData data)
    {
        Player MyPlayer = Player.GetInstance();
        data.MyPlayerData = new PlayerData(MyPlayer.CurrentLevel, MyPlayer.HasSword, MyPlayer.GetHealth(), MyPlayer.GetHunger(), MyPlayer.GetSpeed(), MyPlayer.posX, MyPlayer.posY, MyPlayer.posZ, MyPlayer.DialogueLine);
    }

    /// <summary>
    /// Initializes the EscapeRoom1Data component.
    /// </summary>
    /// <param name="data">The entire save object</param>
    private void SaveEscaperoom1Data(SaveData data)
    {
        data.MyEscapeRoom1Data = new EscapeRoom1Data(GameObject.Find("Pillow shading").transform.position.x);
        Debug.Log(GameObject.Find("Pillow shading").transform.position.x);
    }

    /// <summary>
    /// Implements the load feature.
    /// </summary>
    public void Load(string path)
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(path, FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(fs);
            LoadPlayer(data);
            SceneChange.LoadScene(data.MyPlayerData.MyLevel);
            fs.Close();
        }
        catch (System.Exception e) {
            Debug.Log("Loading issue!" + e);
        }
    }

    /// <summary>
    /// Loads the player saved data into the current player object.
    /// </summary>
    /// <param name="data">The entire save object</param>
    private void LoadPlayer(SaveData data)
    {
        Player MyPlayer = Player.GetInstance();
        MyPlayer.CurrentLevel = data.MyPlayerData.MyLevel;
        MyPlayer.HasSword = data.MyPlayerData.MyHasSword;
        MyPlayer.SetHealth(data.MyPlayerData.MyHealth);
        MyPlayer.SetHunger(data.MyPlayerData.MyHunger);
        MyPlayer.SetSpeed(data.MyPlayerData.MySpeed);
        MyPlayer.posX = data.MyPlayerData.MyX;
        MyPlayer.posY = data.MyPlayerData.MyY;
        MyPlayer.posZ = data.MyPlayerData.MyZ;
        MyPlayer.DialogueLine = data.MyPlayerData.MyDialogueLine;
    }

    /// <summary>
    /// Loads the first EscapeRoom data.
    /// </summary>
    /// <param name="data">The entire save object</param>
    private void LoadEscapeRoom1Data(SaveData data)
    {
        Debug.Log(data.MyEscapeRoom1Data.MyPernaX);
        Debug.Log(GameObject.Find("perna").name);
        if (data.MyEscapeRoom1Data.MyPernaX != GameObject.Find("perna").transform.position.x)
        {
            GameObject.Find("perna").transform.Translate(4, 0, 0);
        }
    }
}
