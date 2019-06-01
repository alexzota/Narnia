using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>OnTriggerWCScript</c> helps operate the toilet object in the second EscapeRoom scene.
/// </summary>
public class OnTriggerWCScript : MonoBehaviour
{
    /// <summary>
    /// The Unity object that displays text
    /// </summary>
    public GameObject text;
    /// <summary>
    /// Indicates whether the player is near this object
    /// </summary>
    private bool near;
    /// <summary>
    /// Indicates whether this object has been moved by the player through interaction
    /// </summary>
    private bool moved;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        text.SetActive(false);
        near = false;
        moved = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (near == true)
        {
            text.SetActive(true);
            if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && moved == false)
            {
                gameObject.transform.Translate(-20, 0, 0);
                moved = true;
            }
        }
    }

    /// <summary>
    /// Defines what should happen as long as the player is inside this object's collider.
    /// </summary>
    void OnTriggerStay2D()
    {
        near = true;
    }

    /// <summary>
    /// Defines what should happen when the player exits this object's collider.
    /// </summary>
    private void OnTriggerExit2D()
    {
        near = false;
        text.SetActive(false);
    }
}

