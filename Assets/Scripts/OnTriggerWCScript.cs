using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWCScript : MonoBehaviour
{
    public GameObject text;
    private bool near;
    private bool moved;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        near = false;
        moved = false;
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
                gameObject.transform.Translate(-20, 0, 0);
                moved = true;
            }
        }
    }

    private void OnTriggerExit2D()
    {
        near = false;
        text.SetActive(false);
    }
}

