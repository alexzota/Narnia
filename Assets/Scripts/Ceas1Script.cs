using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Ceas1Script</c> helps operate the puzzle.
/// </summary>
public class Ceas1Script : MonoBehaviour
{
    /// <summary>
    /// The correct hour to unlock the next level
    /// </summary>
    [SerializeField]
    private int correctHour;
    /// <summary>
    /// A refference to the puzzle's Unity sprite object
    /// </summary>
    private Sprite mySprite = null;
    /// <summary>
    /// The common part of all images' path.
    /// </summary>
    private string defaultPath = "ceas1-";
    /// <summary>
    /// The full image path
    /// </summary>
    private string path;
    /// <summary>
    /// The currently set hour.
    /// </summary>
    private int contor = 1;

    /// <summary>
    /// Indicates whether the correct hour has been set on this object.
    /// </summary>
    /// <returns>True if the correct hour has been set on this object and false otherwise</returns>
    public bool CorrectHourFunction()
    {
        if (contor == correctHour) return true;
        return false;
    }

    /// <summary>
    /// Defines what should happen when this object is moused over.
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            path = "";
            contor += 1;
            if (contor == 9) contor = 1;
            path = defaultPath + contor;
            mySprite = Resources.Load<Sprite>(path);
            GetComponent<SpriteRenderer>().sprite = mySprite;
        }
    }
}
