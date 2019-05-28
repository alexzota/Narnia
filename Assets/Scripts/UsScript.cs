using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsScript : MonoBehaviour
{
    public GameObject text;
    public Canvas ticket;
    public Canvas demoover;

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

    private void OnTriggerExit2D()
    {
        near = false;
        ticket.sortingOrder = -1;
        ticketVisible = false;
        text.SetActive(false);
    }
}
