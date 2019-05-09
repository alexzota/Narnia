using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Tutorial":
                    {
                        SceneManager.LoadScene("EscapeRoom1", LoadSceneMode.Single);
                        PlayerController player = PlayerController.GetInstance();
                        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
                        player.gameObject.transform.localPosition = new Vector3(-57F,-24F,1F);
                        player.SetSpeed(30);
                        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
                        break;
                    }
                case "EscapeRoom1":
                    {
                        SceneManager.LoadScene("EscapeRoom2", LoadSceneMode.Single);
                        break;
                    }
                case "EscapeRoom2":
                    {
                        SceneManager.LoadScene("EscapeRoom1", LoadSceneMode.Single);
                        break;
                    }
            }
        }
    }
}
