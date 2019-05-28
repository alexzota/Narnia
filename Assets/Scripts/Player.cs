using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>Player</c> provides basic control for the player character
/// </summary>
public class Player : Character
{
    /// <summary>
    /// Indicates whether the sword has been picked up or not
    /// </summary>
    public bool HasSword { get; set; }
    /// <summary>
    /// Singleton instance
    /// </summary>
    private static Player instance;
    /// <summary>
    /// The name of the current level
    /// </summary>
    public string CurrentLevel { get; set; }
    /// <summary>
    /// The player's x coordinate.
    /// </summary>
    public float posX { get; set; }
    /// <summary>
    /// The player's y coordinate.
    /// </summary>
    public float posY { get; set; }
    /// <summary>
    /// The player's z coordinate.
    /// </summary>
    public float posZ { get; set; }
    /// <summary>
    /// Awake is called before Start.
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
    protected override void Start()
    {
        base.Start();
        //CurrentLevel = "Tutorial";
        InvokeRepeating("Starve", 0, 3F);
        CurrentLevel = "Tutorial";
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    protected override void Update()
    {
        GetInput();
        base.Update();
        posX = this.transform.position.x;
        posY = this.transform.position.y;
        posZ = this.transform.position.z;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("title", LoadSceneMode.Single);
        }
    }

    /// <summary>
    /// Returns instance.
    /// </summary>
    /// <returns>The only instance to this class.</returns>
    public static Player GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// Gradually decreases the player's hunger.
    /// </summary>
    private void Starve() {
        hunger.Decrease(5);
        if (hunger.IsEmpty())
            health.Decrease(5);
    }

    /// <summary>
    /// Accepts directions input.
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}
