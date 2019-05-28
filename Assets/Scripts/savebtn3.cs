using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class savebtn3 : MonoBehaviour
{
    public SaveManager sv;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string path = Application.persistentDataPath + "/" + "save3.dat";
            Debug.Log(path);
            sv.Save(path);
        }
    }
}
