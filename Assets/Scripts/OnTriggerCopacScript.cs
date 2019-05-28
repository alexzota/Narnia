using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>OnTriggerCopacScript</c> helps operate objects in the EscapeRoom scenes.
/// </summary>
public class OnTriggerCopacScript : MonoBehaviour
{
    /// <summary>
    /// The Unity object that displays text
    /// </summary>
    public GameObject text;
    /// <summary>
    /// The Unity object that appears after interaction
    /// </summary>
    public GameObject ticket;
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
                ticket.GetComponent<SpriteRenderer>().sortingOrder = 10;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                ticketVisible = true;
            }
            else if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && ticketVisible == true)
            {
                ticket.GetComponent<SpriteRenderer>().sortingOrder = -1;
                ticketVisible = false;
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
        ticket.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ticketVisible = false;
        text.SetActive(false);
    }
}
