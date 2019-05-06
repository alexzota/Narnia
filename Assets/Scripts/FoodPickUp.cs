using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUp : MonoBehaviour
{

    private float foodAmount;

    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.tag)
        {
            case "dovleac": { foodAmount = 30; break; }
            case "portocala": { foodAmount = 20; break; }
            case "mandarina": { foodAmount = 10; break; }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (!player.IsAtMaxHunger())
            {
                player.AddHunger(foodAmount);
                Destroy(gameObject);
            }
        }
    }
}
