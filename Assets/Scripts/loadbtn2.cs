using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Class <c>loadbtn2</c> helps call the load feature for the second save button.
/// </summary>
public class loadbtn2 : MonoBehaviour
{
    /// <summary>
    /// The SaveManager used to call the load feature.
    /// </summary>
    public SaveManager sv;

    /// <summary>
    /// Defines what should happen when hovering over this scripts' object.
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Portrait.GetInstance().gameObject.SetActive(true);
            string path = Application.persistentDataPath + "/" + "save2.dat";
            Debug.Log(path);
            sv.Load(path);
            Player.GetInstance().StopStarving();
            Player.GetInstance().StartStarving(0);
        }
    }
}
