using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>OnTriggerDulapScript</c> helps operate the tree object in the first EscapeRoom scene.
/// </summary>
public class OnTriggerDulapScript : MonoBehaviour
{
    /// <summary>
    /// The Unity object that displays text
    /// </summary>
    public GameObject text;
    /// <summary>
    /// The Unity object that represents the drawer
    /// </summary>
    public GameObject sertar;
    /// <summary>
    /// The script associated to the first clock
    /// </summary>
    public Ceas1Script ceas1;
    /// <summary>
    /// The script associated to the second clock
    /// </summary>
    public Ceas1Script ceas2;
    /// <summary>
    /// The script associated to the third clock
    /// </summary>
    public Ceas1Script ceas3;
    /// <summary>
    /// The Unity object that represents the door
    /// </summary>
    public GameObject usa;
    /// <summary>
    /// Indicates whether all of the clock objects have been assigned the correct hour
    /// </summary>
    private static bool correctClocks = false;
    /// <summary>
    /// A refference to the Unity animator object
    /// </summary>
    private Animator animator;
    /// <summary>
    /// Indicates whether the player is near this object
    /// </summary>
    private bool near;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        text.SetActive(false);
        near = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
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

    /// <summary>
    /// Getter for the correctClocks variable.
    /// </summary>
    /// <returns>The correctClocks variable</returns>
    public static bool GetCorrectClocks()
    {
        return correctClocks;
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
        text.SetActive(false);
        sertar.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ceas3.GetComponent<SpriteRenderer>().sortingOrder = -1;
        animator.SetBool("apasat", false);
    }
}
