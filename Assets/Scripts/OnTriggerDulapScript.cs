using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDulapScript : MonoBehaviour
{
    public GameObject text;
    public GameObject sertar;
    public Ceas1Script ceas1;
    public Ceas1Script ceas2;
    public Ceas1Script ceas3;
    public GameObject usa;
    private static bool correctClocks = false;

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
                    if (animator.GetBool("apasat"))
                    {
                        animator.SetBool("apasat", false);
                        sertar.GetComponent<SpriteRenderer>().sortingOrder = -1;
                        ceas1.GetComponent<SpriteRenderer>().sortingOrder = -1;
                        ceas2.GetComponent<SpriteRenderer>().sortingOrder = -1;
                        ceas3.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    }
                    else
                    {
                        animator.SetBool("apasat", true);
                        sertar.GetComponent<SpriteRenderer>().sortingOrder = 10;
                        ceas1.GetComponent<SpriteRenderer>().sortingOrder = 11;
                        ceas2.GetComponent<SpriteRenderer>().sortingOrder = 11;
                        ceas3.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    
                    }
                }
        }

        if (ceas1.CorrectHourFunction() && ceas2.CorrectHourFunction() && ceas3.CorrectHourFunction())
        {
            correctClocks = true;
            GameObject.Find("usa").GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    public static bool GetCorrectClocks() {
        return correctClocks;
    }

    private void OnTriggerExit2D()
    {
        near = false;
        text.SetActive(false);
        sertar.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas3.GetComponent<SpriteRenderer>().sortingOrder = -1;
        animator.SetBool("apasat", false);
    }
}
