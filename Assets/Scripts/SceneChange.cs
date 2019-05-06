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
