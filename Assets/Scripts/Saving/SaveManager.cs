using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Load();
        }
    }

    public void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/" + "test.dat", FileMode.Create);
            SaveData data = new SaveData();
            SavePlayer(data);
            switch (data.MyPlayerData.MyLevel)
            {
                case "Tutorial":
                    break;
                case "EscapeRoom1":
                    SaveEscaperoom1Data(data);
                    break;
                case "EscapeRoom2":
                    break;
            }
            bf.Serialize(fs, data);
            fs.Close();
        }
        catch (System.Exception)
        {}
    }

    private void SavePlayer(SaveData data)
    {
        Player MyPlayer = Player.GetInstance();
        data.MyPlayerData = new PlayerData(MyPlayer.CurrentLevel, MyPlayer.HasSword, MyPlayer.GetHealth(), MyPlayer.GetHunger(), MyPlayer.GetSpeed(), MyPlayer.posX, MyPlayer.posY, MyPlayer.posZ);
    }

    private void SaveEscaperoom1Data(SaveData data)
    {
        data.MyEscapeRoom1Data = new EscapeRoom1Data(GameObject.Find("Pillow shading").transform.position.x);
        Debug.Log(GameObject.Find("Pillow shading").transform.position.x);
    }

    public void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/" + "test.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(fs);
            LoadPlayer(data);
            SceneChange.LoadScene(data.MyPlayerData.MyLevel);
            switch (data.MyPlayerData.MyLevel)
            {
                case "Tutorial":
                    break;
                case "EscapeRoom1":
                    LoadEscapeRoom1Data(data);
                    break;
                case "EscapeRoom2":
                    break;
            }
            fs.Close();
        }
        catch (System.Exception) {}
    }

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
    }

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
