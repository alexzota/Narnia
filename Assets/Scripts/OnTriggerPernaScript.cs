using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPernaScript : MonoBehaviour
{
    public GameObject text;
    public GameObject ticket;
    private bool ticketVisible;
    private bool near;
    private bool moved;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        near = false;
        moved = false;
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
            if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && moved == false)
            {
                gameObject.transform.Translate(4, 0, 0);
                moved = true;
            }
            else if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && moved == true && ticketVisible == false)
            {
                ticket.GetComponent<SpriteRenderer>().sortingOrder = 10;
                ticketVisible = true;
            }
            else if (text.activeInHierarchy == true && Input.GetButtonDown("Use") && moved == true && ticketVisible == true)
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
