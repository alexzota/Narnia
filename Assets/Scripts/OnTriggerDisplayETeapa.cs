using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDisplayETeapa : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            text.SetActive(true);
        }
    }

    void Update()
    {

    }
    private void OnTriggerExit2D()
    {
        text.SetActive(false);
    }
}
