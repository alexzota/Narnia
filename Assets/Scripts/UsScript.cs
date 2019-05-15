using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsScript : MonoBehaviour
{
    public GameObject text;
    public GameObject ticket;
    private bool ticketVisible;
    private bool near;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        near = false;
        ticketVisible = false;
    }

    // Update is called once per frame
    void OnTriggerStay2D()
    {
        near = true;
    }

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

    private void OnTriggerExit2D()
    {
        near = false;
        ticket.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ticketVisible = false;
        text.SetActive(false);
    }
}
