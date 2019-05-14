using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private bool hasSword = false;
    private static PlayerController instance;

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

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Starve", 0, 3F);
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
    }

    public static PlayerController GetInstance()
    {
        return instance;
    }

    public bool GetHasSword()
    {
        return hasSword;
    }

    public void SetHasSword(bool x)
    {
        hasSword = x;
    }

    private void Starve() {
        hunger.Decrease(1);
        if (hunger.IsEmpty())
            health.Decrease(5);
    }

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.Decrease(20);
        }
    }
}
