using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>OnTriggerDisplayETeapa</c> helps operate objects in the EscapeRoom scenes.
/// </summary>
public class OnTriggerDisplayETeapa : MonoBehaviour
{
    /// <summary>
    /// The Unity object that displays text
    /// </summary>
    public GameObject text;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        text.SetActive(false);
    }

    /// <summary>
    /// Defines what should happen as long as the player is inside this object's collider.
    /// </summary>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            text.SetActive(true);
        }
    }

    /// <summary>
    /// Defines what should happen when the player exits this object's collider.
    /// </summary>
    private void OnTriggerExit2D()
    {
        text.SetActive(false);
    }
}
