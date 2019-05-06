using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    // Update is called once per frame
    [SerializeField]
    private Stat health;
    private float startingHealth = 50F;
    private float maxHealth = 100F;
    [SerializeField]
    private Stat hunger;
    private float startingHunger = 70F;
    private float maxHunger = 100F;
    private bool hasSword = false;


    protected override void Start()
    {
        health.Initialize(startingHealth, maxHealth);
        hunger.Initialize(startingHunger, maxHunger);
        base.Start();
        InvokeRepeating("Starve", 0, 3F);
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
    }

    public bool GetHasSword()
    {
        return hasSword;
    }
    public void SetHasSword(bool x)
    {
        hasSword = x;
    }


    public bool IsAtMaxHealth()
    {
        return health.IsFull();
    }

    public void AddHealth(float healthAmount)
    {
        health.Increase(healthAmount);
    }

    public bool IsAtMaxHunger()
    {
        return hunger.IsFull();
    }

    public void AddHunger(float foodAmount)
    {
        hunger.Increase(foodAmount);
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
    }
}
