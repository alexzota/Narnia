using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class savebtn1 : MonoBehaviour
{
    Player player = Player.GetInstance();

    public SaveManager sv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(player.CurrentLevel, LoadSceneMode.Single);
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string path = Application.persistentDataPath +"/" + "save1.dat";
            Debug.Log(path);
            sv.Save(path);
        }
    }
}
