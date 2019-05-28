using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>DialogueManager</c> helps in managing the tutorial dialog boxes.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// Parameter to display the dialogue for Peter.
    /// </summary>
    public TextMeshProUGUI dialogueTextPeter;
    /// <summary>
    /// Parameter to hold the dialogue for Aslan.
    /// </summary>
    public TextMeshProUGUI dialogueTextAslan;
    /// <summary>
    /// Reference to an UI component for Aslan's dialogue box.
    /// </summary>
    public GameObject dialogueBoxAslan;
    /// <summary>
    /// Refence to an UI component for Peter's dialogue box.
    /// </summary>
    public GameObject dialogueBoxPeter;
    /// <summary>
    /// Holds the sentences that will be displayed on screen.
    /// </summary>
    [TextArea(3, 11)]
    public string[] sentences;
    /// <summary>
    /// An index to keep count of the current sentence displayed on screen.
    /// </summary>
    public int currentLine;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        dialogueBoxAslan.SetActive(false);
        dialogueBoxPeter.SetActive(false);
    }

    /// <summary>
    /// Update is called once every frame.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentLine++;
            if (currentLine == 2 || currentLine == 5 || currentLine == 9)
            {
                dialogueBoxAslan.SetActive(false);
                dialogueBoxPeter.SetActive(true);
            }
            else
            {
                dialogueBoxPeter.SetActive(false);
                dialogueBoxAslan.SetActive(true);
            }
        }
        if(currentLine>=sentences.Length)
        {

            dialogueBoxAslan.SetActive(false);
            dialogueBoxPeter.SetActive(false);
            
        }
        dialogueTextAslan.text = sentences[currentLine];
        dialogueTextPeter.text = sentences[currentLine];
    }
}
