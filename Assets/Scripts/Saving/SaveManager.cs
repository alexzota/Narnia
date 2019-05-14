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
            Debug.Log(Player.GetInstance().CurrentLevel);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Load();
            Debug.Log(Player.GetInstance().CurrentLevel);
            Debug.Log(Player.GetInstance().HasSword);
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
            bf.Serialize(fs, data);
            fs.Close();
        }
        catch (System.Exception)
        {}
    }
    private void SavePlayer(SaveData data)
    {
        Player MyPlayer = Player.GetInstance();
        data.MyPlayerData = new PlayerData(MyPlayer.CurrentLevel, MyPlayer.HasSword);
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
            fs.Close();
        }
        catch (System.Exception) {}
    }
    private void LoadPlayer(SaveData data)
    {
        Player MyPlayer = Player.GetInstance();
        MyPlayer.CurrentLevel = data.MyPlayerData.MyLevel;
        MyPlayer.HasSword = data.MyPlayerData.MyHasSword;
    }
}
