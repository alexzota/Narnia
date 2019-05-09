using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDulapScript : MonoBehaviour
{
    public GameObject text;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(true);
            if (text.activeInHierarchy == true && Input.GetButtonDown("E"))
            {
                animator = other.GetComponent<Animator>();
                animator.SetFloat("open", 1 );
            }
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
