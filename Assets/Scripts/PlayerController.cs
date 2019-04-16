using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    // Update is called once per frame
    [SerializeField]
    private Stat health;
    private float startingHealth = 100F;
    [SerializeField]
    private Stat hunger;
    private float startingHunger = 100F;

    protected override void Start()
    {
        health.Initialize(startingHealth, startingHealth);
        hunger.Initialize(startingHunger, startingHunger);
        base.Start();
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
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
    }
}
