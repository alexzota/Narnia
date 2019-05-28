using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Character</c> defines an in-game character
/// </summary>
public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// The character's health
    /// </summary>
    [SerializeField]
    protected Stat health;
    /// <summary>
    /// The character's starting health value
    /// </summary>
    protected float startingHealth = 50F;
    /// <summary>
    /// The character's maximum health value
    /// </summary>
    protected float maxHealth = 100F;
    /// <summary>
    /// The character's hunger
    /// </summary>
    [SerializeField]
    protected Stat hunger;
    /// <summary>
    /// The character's starting hunger value
    /// </summary>
    protected float startingHunger = 70F;
    /// <summary>
    /// The character's maximum hunger value
    /// </summary>
    protected float maxHunger = 100F;
    /// <summary>
    /// The character's movement speed
    /// </summary>
    [SerializeField]
    protected float speed;
    /// <summary>
    /// The character's direction
    /// </summary>
    protected Vector2 direction;
    /// <summary>
    /// The character's animator object
    /// </summary>
    protected Animator animator;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        health.Initialize(startingHealth, maxHealth);
        hunger.Initialize(startingHunger, maxHunger);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    protected virtual void Update()
    {
        if (health.IsEmpty() == false)
            Move();
        else
            Die();
    }

    /// <summary>
    /// Sets the character's speed to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The character`s movement speed value</param>
    public void SetSpeed(float value)
    {
        speed = value;
    }

    /// <summary>
    /// Gets the character's speed.
    /// </summary>
    /// <returns>A float value equal to the character's speed</returns>
    public float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Sets the character`s health to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The character`s health value</param>
    public void SetHealth(float value)
    {
        health.SetCurrentValue(value);
    }

    /// <summary>
    /// Gets the character's health.
    /// </summary>
    /// <returns>A float value equal to the character's health</returns>
    public float GetHealth()
    {
        return health.GetCurrentValue();
    }

    /// <summary>
    /// Sets the character's hunger to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The character's hunger value</param>
    public void SetHunger(float value)
    {
        hunger.SetCurrentValue(value);
    }

    /// <summary>
    /// Gets the character's hunger.
    /// </summary>
    /// <returns>A float value equal to the character's hunger</returns>
    public float GetHunger()
    {
        return hunger.GetCurrentValue();
    }

    /// <summary>
    /// Indicates whether the character's health is at maximum value.
    /// </summary>
    /// <returns>True if the character's health is at maximum value and false otherwise</returns>
    public bool IsAtMaxHealth()
    {
        return health.IsFull();
    }

    /// <summary>
    /// Indicates whether the character's hunger is at maximum value.
    /// </summary>
    /// <returns>True if the character's hunger is at maximum value and false otherwise</returns>
    public bool IsAtMaxHunger()
    {
        return hunger.IsFull();
    }

    /// <summary>
    /// Increases the character's health by a value equal to <paramref name="healthAmount"/>.
    /// </summary>
    /// <param name="healthAmount">The value to be added to the character's health</param>
    public void AddHealth(float healthAmount)
    {
        health.Increase(healthAmount);
    }

    /// <summary>
    /// Increases the character's hunger by a value equal to <paramref name="foodAmount"/>.
    /// </summary>
    /// <param name="foodAmount">The value to be added to the character's hunger</param>
    public void AddHunger(float foodAmount)
    {
        hunger.Increase(foodAmount);
    }

    /// <summary>
    /// Moves the character if needed.
    /// </summary>
    private void Move()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0)
            AnimateMovement(direction);
        else
            ActivateLayer("Idle Layer");
    }

    /// <summary>
    /// Plays the character's death animation.
    /// </summary>
    private void Die()
    {
        ActivateLayer("Death Layer");
        animator.SetBool("is_dead", true);
    }

    /// <summary>
    /// Selects the character's appropiate movement animation based on <paramref name="direction"/>.
    /// </summary>
    /// <param name="direction">The direction the character is moving in</param>
    private void AnimateMovement(Vector2 direction)
    {
        ActivateLayer("Walk Layer");
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    /// <summary>
    /// Activates the animation layer specified by <paramref name="layerName"/>.
    /// </summary>
    /// <param name="layerName">The animation layer to be activated</param>
    private void ActivateLayer(string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }
}
