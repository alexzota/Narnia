using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>SwordPickUp</c> helps interact with the sword item found in the Tutorial scene.
/// </summary>
public class SwordPickUp : MonoBehaviour
{
    /// <summary>
    /// Defines the interaction between this object and the one that collides with it.
    /// </summary>
    /// <param name="other">The object that entered the collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.GetInstance().HasSword = true;
            Destroy(gameObject);
        }
    }
}
