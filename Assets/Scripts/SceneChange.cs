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


    public static void LoadScene(string scene)
    {
        Player player = Player.GetInstance();
        switch (scene)
        {
            case "Tutorial": { UpdateTutorial(player.posX, player.posY, player.posZ); break; }
            case "EscapeRoom1": { UpdateEscapeRoom1(player.posX, player.posY, player.posZ); break; }
            case "EscapeRoom2": { UpdateEscapeRoom2(player.posX, player.posY, player.posZ); break; }
        }
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        player.CurrentLevel = scene;
    }
    public static void LoadSceneFirstScreen(string scene)
    {

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Player player = Player.GetInstance();
        player.CurrentLevel = "Tutorial";
        UpdateTutorial(); 
    }

    private static void UpdateTutorial()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(2F, 2F, 1F);
        player.gameObject.transform.localPosition = new Vector3(7F, 3F, 0F);
        player.SetSpeed(5);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;

    }
    private static void UpdateTutorial(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(2F, 2F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(5);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }



    private static void UpdateEscapeRoom1()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-57F, -24F, 1F);
        player.SetSpeed(30);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }
    private static void UpdateEscapeRoom1(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(30);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }



    private static void UpdateEscapeRoom2()
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(45F, 55F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-48F, -34F, 1F);
        player.SetSpeed(50);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }
    private static void UpdateEscapeRoom2(float x, float y, float z)
    {
        Player player = Player.GetInstance();
        player.gameObject.transform.localScale = new Vector3(-48F, -34F, 1F);
        player.gameObject.transform.localPosition = new Vector3(x, y, z);
        player.SetSpeed(50);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }
}
