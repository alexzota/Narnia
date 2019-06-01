using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Class <c>savebtn3</c> helps call the save feature for the third save button.
/// </summary>
public class savebtn3 : MonoBehaviour
{
    /// <summary>
    /// The SaveManager used to call the save feature.
    /// </summary>
    public SaveManager sv;

    /// <summary>
    /// Defines what should happen when hovering over this scripts' object.
    /// </summary>
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
