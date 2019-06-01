using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class <c>save</c> operates the save button in order to provide access to the scene with the saved games.
/// </summary>
public class save : MonoBehaviour
{
    /// <summary>
    /// Defines what should happen when hovering over this scripts' object.
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("save", LoadSceneMode.Single);
        }
    }
}
