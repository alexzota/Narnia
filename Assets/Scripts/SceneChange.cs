using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>SceneChange</c> is used to navigate between the game's scenes.
/// </summary>
public class SceneChange : MonoBehaviour
{
    /// <summary>
    /// Defines the interaction between this object and the one that collides with it.
    /// </summary>
    /// <param name="other">The object that entered the collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string sceneName = Player.GetInstance().CurrentLevel;
            if (sceneName == "Tutorial" && Player.GetInstance().HasSword)
            {
                UpdateEscapeRoom1();
                SceneManager.LoadScene("EscapeRoom1", LoadSceneMode.Single);
                Player.GetInstance().CurrentLevel = "EscapeRoom1";
            }
            else if (sceneName == "EscapeRoom1" && OnTriggerDulapScript.GetCorrectClocks())
            {
                UpdateEscapeRoom2();
                SceneManager.LoadScene("EscapeRoom2", LoadSceneMode.Single);
                Player.GetInstance().CurrentLevel = "EscapeRoom2";
            }
        }
    }

    /// <summary>
    /// Loads the scene with the name <paramref name="scene"/>.
    /// </summary>
    /// <param name="scene">The name of the scene to be loaded</param>
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Player player = Player.GetInstance();
        switch (scene)
        {
            case "Tutorial": { UpdateTutorial(player.posX, player.posY, player.posZ); break; }
            case "EscapeRoom1": { UpdateEscapeRoom1(player.posX, player.posY, player.posZ); break; }
            case "EscapeRoom2": { UpdateEscapeRoom2(player.posX, player.posY, player.posZ); break; }
        }
        player.CurrentLevel = scene;
    }

    /// <summary>
    /// Makes the transition between the menu and a scene.
    /// </summary>
    /// <param name="scene">The scene's name</param>
    public static void LoadSceneFromMenu(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Player player = Player.GetInstance();
        player.CurrentLevel = scene;
        UpdateTutorial(); 
    }

    /// <summary>
    /// Makes the needed preparations before loading the Tutorial scene at the start of the game.
    /// </summary>
    private static void UpdateTutorial()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(2F, 2F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-5.23F, 0.34F, 0F);
        player.SetSpeed(5);
        player.SetHealth(player.GetStartingHealth());
        player.SetHunger(player.GetStartingHunger());
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    /// <summary>
    /// Makes the needed preparations before loading the Tutorial scene after it's been saved.
    /// </summary>
    /// <param name="x">The player's x coordinate.</param>
    /// <param name="y">The player's y coordinate.</param>
    /// <param name="z">The player's z coordinate.</param>
    private static void UpdateTutorial(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(2F, 2F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(5);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }


    /// <summary>
    /// Makes the needed preparations before loading the first EscapeRoom scene at the start of the game.
    /// </summary>
    private static void UpdateEscapeRoom1()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-57F, -24F, 1F);
        player.SetSpeed(30);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }

    /// <summary>
    /// Makes the needed preparations before loading the first EscapeRoom scene after it's been saved.
    /// </summary>
    /// <param name="x">The player's x coordinate.</param>
    /// <param name="y">The player's y coordinate.</param>
    /// <param name="z">The player's z coordinate.</param>
    private static void UpdateEscapeRoom1(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(30);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }

    /// <summary>
    /// Makes the needed preparations before loading the second EscapeRoom scene at the start of the game.
    /// </summary>
    private static void UpdateEscapeRoom2()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(45F, 55F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-48F, -34F, 1F);
        player.SetSpeed(50);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }

    /// <summary>
    /// Makes the needed preparations before loading the second EscapeRoom scene after it's been saved. 
    /// </summary>
    /// <param name="x">The player's x coordinate.</param>
    /// <param name="y">The player's x coordinate.</param>
    /// <param name="z">The player's x coordinate.</param>
    private static void UpdateEscapeRoom2(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(48F, 34F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(50);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }
}
