using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

/// <summary>
/// Class <c>new_game</c> operates the 'New Game' button to initialize a new game.
/// </summary>
public class new_game : MonoBehaviour
{
    /// <summary>
    /// Defines what should happen when hovering over this script's object.
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneChange.LoadSceneFromMenu("Tutorial");
            Portrait.GetInstance().gameObject.SetActive(true);
            Player.GetInstance().StartStarving(30);
            Player.GetInstance().DialogueLine = 0;
        }
    }
}
