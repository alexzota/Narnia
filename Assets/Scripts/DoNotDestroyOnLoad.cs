using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>DoNotDestroyOnLoad</c> is a singleton that helps keep objects it's attached to active when loading or switching the scene. It also enables and disables the menu.
/// </summary>
public class DoNotDestroyOnLoad : MonoBehaviour
{
    /// <summary>
    /// The only instance of this class.
    /// </summary>
    private static DoNotDestroyOnLoad instance;

    /// <summary>
    /// Awake funtion is called before Start().
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "menu":
                    SceneChange.LoadScene(Player.GetInstance().CurrentLevel);
                    Portrait.GetInstance().gameObject.SetActive(true);
                    Player.GetInstance().StartStarving();
                    break;
                default:
                    SceneManager.LoadScene("menu", LoadSceneMode.Single);
                    Portrait.GetInstance().gameObject.SetActive(false);
                    Player.GetInstance().StopStarving();
                    break;
            }

        }
    }
}
