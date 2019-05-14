using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected Stat health;
    protected float startingHealth = 50F;
    protected float maxHealth = 100F;
    [SerializeField]
    protected Stat hunger;
    protected float startingHunger = 70F;
    protected float maxHunger = 100F;
    [SerializeField]
    protected float speed;
    protected Vector2 direction;
    protected Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        health.Initialize(startingHealth, maxHealth);
        hunger.Initialize(startingHunger, maxHunger);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (health.IsEmpty() == false)
            Move();
        else
            Die();
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    private void Move()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0)
            AnimateMovement(direction);
        else
            ActivateLayer("Idle Layer");
    }

    private void Die()
    {
        ActivateLayer("Death Layer");
        animator.SetBool("is_dead", true);
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

    public void AnimateMovement(Vector2 direction)
    {
        ActivateLayer("Walk Layer");
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    public void ActivateLayer(string layer)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layer), 1);
    }
}
