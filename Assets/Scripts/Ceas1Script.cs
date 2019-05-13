using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceas1Script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int correctHour;

    private Sprite mySprite = null;
    private string defaultPath = "ceas1-";
    private string path;
    private int contor = 1;
    void Start()
    {
    }

    public bool CorrectHourFunction()
    {
        if (contor == correctHour) return true;
        return false;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            path = "";
            contor += 1;
            if (contor == 9) contor = 1;
            path = defaultPath + contor;
            mySprite = Resources.Load<Sprite>(path);
            GetComponent<SpriteRenderer>().sprite = mySprite;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
