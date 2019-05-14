using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public float healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 20;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.IsAtMaxHealth())
            {
                player.AddHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
