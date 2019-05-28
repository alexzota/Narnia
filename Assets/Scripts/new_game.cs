using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class new_game : MonoBehaviour
{
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneChange.LoadSceneFromMenu("Tutorial");
            Portrait.GetInstance().gameObject.SetActive(true);
            Player.GetInstance().StartStarving();
            Player.GetInstance().DialogueLine = 0;
        }
    }
}
