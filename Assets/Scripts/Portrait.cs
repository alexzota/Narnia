using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>Portrait</c> is a singleton that helps keep objects it's attached to active when loading or switching the scene.
/// </summary>
public class Portrait : MonoBehaviour
{
    /// <summary>
    /// The only instance of this class.
    /// </summary>
    private static Portrait instance;

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

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public static Portrait GetInstance()
    {
        return instance;
    }
}
