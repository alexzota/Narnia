using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>exit</c> handles the exit button.
/// </summary>
public class exit : MonoBehaviour
{
    /// <summary>
    /// Stops the application.
    /// </summary>
    public void doExit()
    {
        Application.Quit();
    }
}
