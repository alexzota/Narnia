using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CurrentLevel = "Tutorial";
        InvokeRepeating("Starve", 0, 3F);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    protected override void Update()
    {
        GetInput();
        base.Update();
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
        hunger.Decrease(1);
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
