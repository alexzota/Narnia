using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>FoodPickUp</c> helps the player interact with food objects found in the world.
/// </summary>
public class FoodPickUp : MonoBehaviour
{
    /// <summary>
    /// The amount of hunger restored by this object
    /// </summary>
    private float foodAmount;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        switch (gameObject.tag)
        {
            case "dovleac": { foodAmount = 30; break; }
            case "portocala": { foodAmount = 20; break; }
            case "mandarina": { foodAmount = 10; break; }
        }
    }

    /// <summary>
    /// Defines the interaction between this object and the one that collides with it.
    /// </summary>
    /// <param name="other">The object that entered the collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.IsAtMaxHunger())
            {
                player.AddHunger(foodAmount);
                Destroy(gameObject);
            }
        }
    }
}
