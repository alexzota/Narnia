using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDulapScript : MonoBehaviour
{
    public GameObject text;
    private Animator animator;
    private bool near;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        text.SetActive(false);
        near = false;
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
                if (text.activeInHierarchy == true && Input.GetButtonDown("Use"))
                {
                    if (animator.GetBool("apasat")) animator.SetBool("apasat", false);
                    else animator.SetBool("apasat", true);
                }
        }
    }
    private void OnTriggerExit2D()
    {
        text.SetActive(false);
        animator.SetBool("apasat", false);
    }
}
