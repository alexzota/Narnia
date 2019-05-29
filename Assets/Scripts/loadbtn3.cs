using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class loadbtn3 : MonoBehaviour
{
    public SaveManager sv;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Portrait.GetInstance().gameObject.SetActive(true);
            string path = Application.persistentDataPath + "/" + "save3.dat";
            Debug.Log(path);
            sv.Load(path);
            Player.GetInstance().StopStarving();
            Player.GetInstance().StartStarving(0);
        }
    }
}
