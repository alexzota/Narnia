using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>HealthPickUp</c> helps the player interact with health objects found in the world.
/// </summary>
public class HealthPickUp : MonoBehaviour
{
    /// <summary>
    /// The amount of health restored by this object
    /// </summary>
    public float healthAmount;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        healthAmount = 20;
    }

    /// <summary>
    /// Defines the interaction between this object and the one that collides with it.
    /// </summary>
    /// <param name="other">The object that entered the collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = Player.GetInstance();
            if (player.IsAtMaxHealth() == false)
            {
                player.AddHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
