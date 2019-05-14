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
                LoadScene("EscapeRoom1");
            else if (sceneName == "EscapeRoom1" && OnTriggerDulapScript.GetCorrectClocks())
                LoadScene("EscapeRoom2");
        }
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Player player = Player.GetInstance();
        player.CurrentLevel = scene;
        player.gameObject.transform.localScale = new Vector3(25F, 35F, 1F);
        player.gameObject.transform.localPosition = new Vector3(-57F, -24F, 1F);
        player.SetSpeed(30);
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }
}
