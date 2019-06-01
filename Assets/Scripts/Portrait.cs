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

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Gets the only instance of this class.
    /// </summary>
    /// <returns>The only instance of this class</returns>
    public static Portrait GetInstance()
    {
        return instance;
    }
}
