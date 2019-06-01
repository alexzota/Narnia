using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>UsScript</c> helps operate the last on the second EscapeRoom scene.
/// </summary>
public class UsScript : MonoBehaviour
{
    /// <summary>
    /// The Unity object that displays text
    /// </summary>
    public GameObject text;
    /// <summary>
    /// The Unity Canvas object that appears after interaction
    /// </summary>
    public Canvas ticket;
    /// <summary>
    /// The Unity Canvas object that display the 'demo over' text
    /// </summary>
    public Canvas demoover;
    /// <summary>
    /// Indicates whether the ticket is visible
    /// </summary>
    private bool ticketVisible;
    /// <summary>
    /// Indicates whether the player is currently near this object
    /// </summary>
    private bool near;


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        text.SetActive(false);
        near = false;
        ticketVisible = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (near == true)
        {
            text.SetActive(true);
            if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && ticketVisible == false)
            {
                ticket.sortingOrder = 7;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                ticketVisible = true;
            }
            else if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && ticketVisible == true)
            {
                InputField stringul = ticket.GetComponentInChildren<InputField>();
               if (stringul.text == "1825") {
                    demoover.sortingOrder = 11;
                }
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
        ticket.sortingOrder = -1;
        ticketVisible = false;
        text.SetActive(false);
    }
}
