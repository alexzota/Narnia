using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>load</c> operates the load button in order to provide access to the scene with the saved games.
/// </summary>
public class load : MonoBehaviour
{
    /// <summary>
    /// Defines what should happen when hovering over this scripts' object.
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("load", LoadSceneMode.Single);
        }
    }
}
